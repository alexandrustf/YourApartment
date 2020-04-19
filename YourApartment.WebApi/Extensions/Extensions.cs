using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YourApartment.WebApi
{
    public static class Extensions
    {
        public static IExtractEmailImplementation ExtractEmailImplementation { get; set; } = new ExtractEmailImplementation();

        public static string ExtractEmail(this HttpContext context) => ExtractEmailImplementation.ExtractEmail(context);

    }
}
