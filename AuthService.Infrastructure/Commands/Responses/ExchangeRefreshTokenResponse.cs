using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.Commands.Responses.Result;

namespace AuthService.Infrastructure.Commands.Responses
{
    public class ExchangeRefreshTokenResponse : Response
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }

        public ExchangeRefreshTokenResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
