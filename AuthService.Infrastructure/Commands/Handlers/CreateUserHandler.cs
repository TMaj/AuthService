using AuthService.Infrastructure.Commands.Commands;
using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.Helpers;
using AuthService.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            return (await userService.CreateAsync(command.Email, command.FirstName,
                 command.LastName, command.Username, command.Password))
                 .SerializeToResult();
        }
    }
}
