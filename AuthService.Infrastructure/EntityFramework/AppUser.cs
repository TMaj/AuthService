using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthService.Infrastructure.EntityFramework
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedTs { get; set; }
        public DateTime ModifiedTs { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        private readonly List<RefreshToken> refreshTokens = new List<RefreshToken>();
        public IReadOnlyCollection<RefreshToken> RefreshTokens => this.refreshTokens.AsReadOnly();

        public AppUser()
        {
        }

        public bool HasValidRefreshToken(string refreshToken)
        {
            return this.refreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
        }

        public void AddRefreshToken(string token, string userId, string remoteIpAddress, double daysToExpire = 5)
        {
            this.refreshTokens.Add(new RefreshToken(token, DateTime.UtcNow.AddDays(daysToExpire), userId, remoteIpAddress));
        }

        public void RemoveRefreshToken(string refreshToken)
        {
            this.refreshTokens.Remove(this.refreshTokens.First(t => t.Token == refreshToken));
        }
    }
}
