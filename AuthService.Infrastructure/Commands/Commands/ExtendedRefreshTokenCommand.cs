namespace AuthService.Infrastructure.Commands.Commands
{
    public class ExtendedRefreshTokenCommand : ExchangeRefreshTokenCommand
    {
        public string SigningKey { get; set; }

        public ExtendedRefreshTokenCommand(ExchangeRefreshTokenCommand command, string signingKey)
        {
            this.AccessToken = command.AccessToken;
            this.RefreshToken = command.RefreshToken;
            this.SigningKey = signingKey;
        }
    }
}
