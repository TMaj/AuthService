using Microsoft.AspNetCore.Mvc;

namespace AuthService.Infrastructure.Commands.Responses.Result
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
