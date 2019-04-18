using AuthService.Infrastructure.Commands.Responses;
using AuthService.Infrastructure.Commands.Responses.Result;
using AuthService.Infrastructure.EntityFramework;
using AuthService.Infrastructure.EntityFramework.Data;
using AuthService.Infrastructure.Helpers;
using AuthService.Infrastructure.Security;
using AuthService.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly AppDbContext dbContext;
        private readonly ITokenFactory tokenFactory;
        private readonly IJwtTokenFactory jwtTokenFactory;

        public UserService(UserManager<AppUser> userManager, AppDbContext dbContext,
            ITokenFactory tokenFactory, IJwtTokenFactory jwtTokenFactory)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.tokenFactory = tokenFactory;
            this.jwtTokenFactory = jwtTokenFactory;
        }

        public Task<IEnumerable<AppUser>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> CreateAsync(string email, string firstname, string lastname, string username, string password)
        {
            var user = new AppUser { Email = email, UserName = username, FirstName = firstname, LastName = lastname };
            var result = await this.userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return new CreateUserResponse(result.Errors.Select(e => new Error(e.Code, e.Description)), false);
            }

            return new CreateUserResponse(user.Id, true, "User sucessfully created");
        }        

        public Task<AppUser> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginUserResponse> LoginAsync(string email, string username, string password, string remoteIpAddress)
        {
            if (email.IsNullOrEmpty() && username.IsNullOrEmpty())
            {
                return new LoginUserResponse(
                    new List<Error> { new Error("login_failure", "Username or email needs to be provided") },
                    false);
            }

            AppUser user = null;

            if (!username.IsNullOrEmpty())
            {
                user = await this.userManager.FindByNameAsync(username);
            }
            else if (!email.IsNullOrEmpty())
            {
                user = await this.userManager.FindByEmailAsync(email);
            }

            if (user == null || !(await this.userManager.CheckPasswordAsync(user, password)))
            {
               return new LoginUserResponse(
               new List<Error> { new Error("login_failure", "Invalid username/email or password") },
               false);
            }

            var refreshToken = this.tokenFactory.GenerateToken();
            user.AddRefreshToken(refreshToken, user.Id, remoteIpAddress);
            await this.userManager.UpdateAsync(user);
            await this.dbContext.SaveChangesAsync();

            return new LoginUserResponse(await this.jwtTokenFactory.GenerateEncodedTokenAsync(user.Id, user.UserName), refreshToken, true);
        }
    }
}
