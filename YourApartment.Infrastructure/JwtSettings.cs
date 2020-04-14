using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Infrastructure
{
    public sealed class JwtSettings
    {
        private JwtSettings()
        {
        }

        public static JwtSettings Dummy => new JwtSettings
        {
            Audience = "Dummy",
            Issuer = "Dummy",
            KeySecret = "E923A186-8AEE-4828-97D9-D890F8AF2BB2",
            SecurityAlgorithm = "HS256",
            TokenExpirationInHours = 24,
        };

        public string Issuer { get; private set; }

        public int TokenExpirationInHours { get; private set; }

        public string KeySecret { get; private set; }

        public string SecurityAlgorithm { get; private set; }

        public string Audience { get; private set; }

        public TimeSpan TokenExpiration => TimeSpan.FromHours(this.TokenExpirationInHours);

        public SecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.KeySecret));
    }
}
