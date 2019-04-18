using AuthService.Infrastructure.Commands.Responses;
using AuthService.Infrastructure.Commands.Responses.Result;
using AuthService.Infrastructure.EntityFramework;
using AuthService.Infrastructure.EntityFramework.Data;
using AuthService.Infrastructure.Security;
using AuthService.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly AppDbContext dbContext;
        private readonly ITokenFactory tokenFactory;
        private readonly IJwtTokenFactory jwtTokenFactory;
        private readonly IJwtTokenValidator tokenValidator;

        public AuthService(UserManager<AppUser> userManager, AppDbContext dbContext,
            ITokenFactory tokenFactory, IJwtTokenFactory jwtTokenFactory, IJwtTokenValidator tokenValidator)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.tokenFactory = tokenFactory;
            this.jwtTokenFactory = jwtTokenFactory;
            this.tokenValidator = tokenValidator;
        }

        public async Task<LoginUserResponse> LoginAsync(string email, string username, string password, string remoteIpAddress)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(username))
            {
                return new LoginUserResponse(
                    new List<Error> { new Error("login_failure", "Username or email needs to be provided") },
                    false);
            }

            AppUser user = null;

            if (!string.IsNullOrEmpty(username))
            {
                user = await this.userManager.FindByNameAsync(username);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                user = await this.userManager.FindByEmailAsync(email);
            }

            if (user == null || !(await this.userManager.CheckPasswordAsync(user, password)))
            {
                return new LoginUserResponse(
                new List<Error> { new Error("login_failure", "Invalid username/email or password") },
                false);
            }

            var tokens = this.dbContext.Users.Where(x => x.Id == user.Id).Include(x => x.RefreshTokens).ToList();

            var refreshToken = this.tokenFactory.GenerateToken();
            user.AddRefreshToken(refreshToken, user.Id, remoteIpAddress);


            await this.userManager.UpdateAsync(user);

            return new LoginUserResponse(await this.jwtTokenFactory.GenerateEncodedTokenAsync(user.Id, user.UserName), refreshToken, true);
        }


        public async Task<ExchangeRefreshTokenResponse> ExchangeRefreshToken(string accessToken, string refreshToken, string signingKey)
        {
            var claimPrincipal = this.tokenValidator.GetPrincipalFromToken(accessToken, signingKey);

            if (claimPrincipal != null)
            {
                var id = claimPrincipal.Claims.First(c => c.Type == "id");
                var user = await this.userManager.Users.Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.Id == id.Value); 

                if ((bool)user?.HasValidRefreshToken(refreshToken))
                {
                    var jwtToken = await this.jwtTokenFactory.GenerateEncodedTokenAsync(user.Id, user.UserName);
                    var newRefreshToken = this.tokenFactory.GenerateToken();
                    user.RemoveRefreshToken(refreshToken); // delete the token we've exchanged
                    user.AddRefreshToken(newRefreshToken, user.Id, ""); // add the new one
                    await this.userManager.UpdateAsync(user);
                    return new ExchangeRefreshTokenResponse(jwtToken, refreshToken, true);
                } 
            }

            return new ExchangeRefreshTokenResponse(false, "Invalid token");
        }
    }
}
