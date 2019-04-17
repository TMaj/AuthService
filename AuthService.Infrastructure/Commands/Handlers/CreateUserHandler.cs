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
    public class CreateUserHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService userService;

        public CreateUserHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<ContentResult> HandleAsync(CreateUserCommand command)
        {
            var response = await userService.CreateAsync(command.Email, command.FirstName,
                 command.LastName, command.Username, command.Password);

            var result = new JsonContentResult();
            result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            result.Content = JsonSerializer.SerializeObject(response);

            return result;
        }
    }
}
