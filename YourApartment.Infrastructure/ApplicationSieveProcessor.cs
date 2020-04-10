using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using YourApartment.Domain;

namespace YourApartment.Infrastructure
{
    public sealed class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(IOptions<SieveOptions> options)
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            var configurations = typeof(ApplicationSieveProcessor)
                .Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i == typeof(ISieveEntityConfiguration)))
                .Select(Activator.CreateInstance);
            foreach (dynamic configuration in configurations)
            {
                configuration.Configure(mapper);
            }

            return mapper;
        }
    }
}
