using AuthService.Infrastructure.Commands.Commands;
using AuthService.Infrastructure.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthService.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController( ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
        }

        /// <summary>
        /// Creates new user account
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]CreateUserCommand command)
        {
            return await DispatchAsync(command);
        }
    }
}
