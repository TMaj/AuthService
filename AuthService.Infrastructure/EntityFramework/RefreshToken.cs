using System;

namespace AuthService.Infrastructure.EntityFramework
{
    public class RefreshToken
    { 
        public Guid Id { get; set; }
         
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }

        public  virtual AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; private set; }

        public RefreshToken()
        {
        }

        public RefreshToken(string token, DateTime expires, string appUserId, string remoteIpAddress)
        {
            Token = token;
            Expires = expires;
            AppUserId = appUserId;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
