using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.Commands.Responses.Result;
using System.Collections.Generic;

namespace AuthService.Infrastructure.Commands.Responses
{
    public class CreateUserResponse : Response
    { 
        public string Id { get; set; }
        public IEnumerable<Error> Errors { get; }

        public CreateUserResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public CreateUserResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
