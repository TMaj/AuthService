using AuthService.Infrastructure.Commands.Responses;
using AuthService.Infrastructure.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<AppUser> GetAsync(string id);
        Task<IEnumerable<AppUser>> BrowseAsync();
        Task<CreateUserResponse> CreateAsync(string email, string firstname, string lastname, string username, string password);
    }
}
