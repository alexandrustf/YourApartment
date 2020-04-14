using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSharpFunctionalExtensions;
using EnsureThat;
using Microsoft.IdentityModel.Tokens;
using YourApartment.Business;
using YourApartment.Domain;

namespace YourApartment.Infrastructure
{
    internal sealed class JwtTokenProvider : ITokenProvider
    {
        private const string RoleClaim = "role";

        private readonly JwtSettings options;

        private readonly IUserService userService;

        public JwtTokenProvider(JwtSettings options, IUserService userService)
        {
            EnsureArg.IsNotNull(options);
            EnsureArg.IsNotNull(userService);

            this.options = options;
            this.userService = userService;
        }

        public Result<AuthenticationToken> GenerateTokenFor(User user)
        {
            return Maybe<User>.From(user).ToResult("Invalid user")
                .OnSuccess(u => CreateToken(u));
        }

        private AuthenticationToken CreateToken(User user)
        {
            var now = DateTime.Now;
            var expirationTime = now.Add(options.TokenExpiration);

            var signingCredentials = new SigningCredentials(options.SecurityKey, options.SecurityAlgorithm);

            var jwtToken = new JwtSecurityToken(
                options.Issuer,
                options.Audience,
                GetClaims(user),
                now,
                expirationTime,
                signingCredentials);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return new AuthenticationToken(encodedToken, expirationTime);
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Iss, options.Issuer),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };
        }
    }
}
