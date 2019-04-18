using AuthService.Infrastructure.Commands.Commands;
using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.Commands.Responses.Result;
using AuthService.Infrastructure.Serialization;
using AuthService.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Commands.Handlers
{
    public class LoginUserHandler : ICommandHandler<ExtendedLoginUserCommand>
    {
        private readonly IUserService userService;

        public LoginUserHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<ContentResult> HandleAsync(ExtendedLoginUserCommand command)
        {
            var response = await userService.LoginAsync(command.Email, command.Username, command.Password, command.RemoteIpAddress);

            var result = new JsonContentResult();
            result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            result.Content = JsonSerializer.SerializeObject(response);

            return result;
        }
    }
}
