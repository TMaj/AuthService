using AuthService.Infrastructure.Commands.Commands;
using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.Helpers;
using AuthService.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Commands.Handlers
{
    public class ExchangeRefreshTokenHandler : ICommandHandler<ExtendedRefreshTokenCommand>
    {
        private readonly IAuthService authService;

        public ExchangeRefreshTokenHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<ContentResult> HandleAsync(ExtendedRefreshTokenCommand command)
        {            
            return (await this.authService.ExchangeRefreshToken(command.AccessToken, command.RefreshToken, command.SigningKey))
                                          .SerializeToResult();
        }
    }
}
