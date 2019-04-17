namespace AuthService.Infrastructure.Commands.Interfaces
{
    public abstract class Response
    {
        public bool Success { get; }
        public string Message { get; }

        protected Response(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
