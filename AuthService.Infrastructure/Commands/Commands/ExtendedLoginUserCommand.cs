namespace AuthService.Infrastructure.Commands.Commands
{
    public class ExtendedLoginUserCommand : LoginUserCommand
    {
        public ExtendedLoginUserCommand(LoginUserCommand command, string ipAddress)
        {
            this.Email = command.Email;
            this.Username = command.Username;
            this.Password = command.Password;
            this.RemoteIpAddress = ipAddress;
        }

        public string RemoteIpAddress { get; set; }
    }
}
