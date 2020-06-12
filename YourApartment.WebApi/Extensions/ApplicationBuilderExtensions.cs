using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using YourApartment.Business;
using YourApartment.Domain;
using YourApartment.Infrastructure;

namespace YourApartment.WebApi
{
    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder CreateDefaultLocation(this IApplicationBuilder app,
             List<DefaultLocationSettings> defaultLocationSettings, ILocationsService locationsService)
        {
            var locationsAsString = defaultLocationSettings.Select(p => p.Location);
            new SeedLocation(new LocationSettings(locationsAsString), locationsService).SeedLocationsAsync().Wait();

            return app;
        }
    }
}
