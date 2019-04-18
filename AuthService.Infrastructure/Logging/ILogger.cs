namespace AuthService.Infrastructure.Logging
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
