using AuthService.Infrastructure.Commands.Commands;
using AuthService.Infrastructure.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthService.Api.Controllers
{
    public class AuthController : ApiControllerBase
    {
        public AuthController(ICommandDispatcher commandDispatcher)
              : base(commandDispatcher)
        {
        }

        /// <summary>
        /// Logs user in
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]LoginUserCommand command)
        {
            return await DispatchAsync(new ExtendedLoginUserCommand(command, Request.HttpContext.Connection.RemoteIpAddress?.ToString()));
        }
    }
}
