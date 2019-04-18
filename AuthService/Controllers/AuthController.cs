using AuthService.Api.Settings;
using AuthService.Infrastructure.Commands.Commands;
using AuthService.Infrastructure.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AuthService.Api.Controllers
{
    public class AuthController : ApiControllerBase
    {
        private readonly AuthSettings authSettings;

        public AuthController(ICommandDispatcher commandDispatcher, IOptions<AuthSettings> authSettings)
              : base(commandDispatcher)
        {
            this.authSettings = authSettings.Value;
        }

        /// <summary>
        /// Logs user in
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
        {
            return await DispatchAsync(new ExtendedLoginUserCommand(command, Request.HttpContext.Connection.RemoteIpAddress?.ToString()));
        }

        /// <summary>
        /// Logs user in
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody]ExchangeRefreshTokenCommand command)
        {
            return await DispatchAsync(new ExtendedRefreshTokenCommand(command, authSettings.SecretKey));
        }
    }
}
