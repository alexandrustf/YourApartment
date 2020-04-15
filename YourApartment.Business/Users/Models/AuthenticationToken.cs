using System;
using System.Collections.Generic;
using System.Text;
using EnsureThat;

namespace YourApartment.Business
{
    public sealed class AuthenticationToken
    {
        public AuthenticationToken(string token, DateTime expirationTime)
        {
            EnsureArg.IsNotNull(token);
            Token = token;
            ExpiresAt = expirationTime;
        }

        public string Token { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
