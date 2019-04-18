using AuthService.Infrastructure.Commands.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Authorize(Policy = "ApiUser")] 
    public class ProtectedController : ApiControllerBase
    {
        public ProtectedController(ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
        }

        /// <summary>
        /// Example protected endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Home()
        {
            return new OkObjectResult(new { result = true });
        }
    }
}
