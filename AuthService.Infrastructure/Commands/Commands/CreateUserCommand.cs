using AuthService.Infrastructure.Commands.Interfaces;

namespace AuthService.Infrastructure.Commands.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
