using System.Security.Claims;

namespace AuthService.Infrastructure.Security
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
