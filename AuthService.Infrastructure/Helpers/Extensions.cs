using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.Commands.Responses.Result;
using AuthService.Infrastructure.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthService.Infrastructure.Helpers
{
    public static class Extensions
    { 
        public static ContentResult SerializeToResult(this Response response)
        {
            var result = new JsonContentResult();
            result.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            result.Content = JsonSerializer.SerializeObject(response);

            return result;
        }
    }
}
