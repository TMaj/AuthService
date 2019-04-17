using AuthService.Infrastructure.Commands.Interfaces;

namespace AuthService.Infrastructure.Commands.Commands
{
    public class LoginUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
