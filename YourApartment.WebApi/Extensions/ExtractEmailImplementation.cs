using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YourApartment.WebApi
{
    public class ExtractEmailImplementation : IExtractEmailImplementation
    {
        public string ExtractEmail(HttpContext context) => context.User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;

    }
}
