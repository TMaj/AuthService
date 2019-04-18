using AuthService.Infrastructure.Commands.Responses.Result;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Security
{
    public interface IJwtTokenFactory
    {
        Task<AccessToken> GenerateEncodedTokenAsync(string id, string userName);
    }
}
