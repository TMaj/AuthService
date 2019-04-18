using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.Commands.Responses.Result;
using System.Collections.Generic;

namespace AuthService.Infrastructure.Commands.Responses
{
    public class LoginUserResponse : Response
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }
        public IEnumerable<Error> Errors { get; }

        public LoginUserResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public LoginUserResponse(AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
