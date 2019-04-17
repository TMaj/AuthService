using AuthService.Infrastructure.Commands.Responses;
using AuthService.Infrastructure.Commands.Responses.Result;
using AuthService.Infrastructure.EntityFramework;
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

        public UserService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
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
    }
}
