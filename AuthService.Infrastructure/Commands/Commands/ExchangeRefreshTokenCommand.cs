using AuthService.Infrastructure.Commands.Interfaces;

namespace AuthService.Infrastructure.Commands.Commands
{
    public class ExchangeRefreshTokenCommand : ICommand
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
