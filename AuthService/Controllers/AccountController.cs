using AuthService.Infrastructure.Commands.Commands;
using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthService.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> userManager, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Creates new user account
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        {
            return await DispatchAsync(command);
        }
    }
}
