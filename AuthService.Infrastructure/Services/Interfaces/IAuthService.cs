using AuthService.Infrastructure.Commands.Responses;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Services.Interfaces
{
    public interface IAuthService : IService
    {
        Task<LoginUserResponse> LoginAsync(string email, string username, string password, string remoteIpAddress);
        Task<ExchangeRefreshTokenResponse> ExchangeRefreshToken(string accessToken, string refreshToken, string signingKey);
    }
}
