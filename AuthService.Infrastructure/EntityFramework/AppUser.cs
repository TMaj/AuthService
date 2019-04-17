using Microsoft.AspNetCore.Identity;
using System;

namespace AuthService.Infrastructure.EntityFramework
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedTs { get; set; }
        public DateTime ModifiedTs { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AppUser()
        {
        }
    }
}
