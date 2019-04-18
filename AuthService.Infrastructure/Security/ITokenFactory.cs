namespace AuthService.Infrastructure.Security
{
    public interface ITokenFactory
    {
        string GenerateToken(int size = 32);
    }
}
