using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using YourApartment.Business;
using System.Linq;
using System.Threading.Tasks;

namespace YourApartment.Infrastructure
{
    public class SeedLocation
    {
        private readonly LocationSettings locationSettings;

        private readonly ILocationsService locationsService;

        public SeedLocation(LocationSettings locationSettings, ILocationsService locationsService)
        {
            this.locationSettings = locationSettings;
            this.locationsService = locationsService;
        }

        public async Task SeedLocationsAsync()
        {
            if(this.locationSettings.Locations.ToList().Count == 0)
                foreach (var location in this.locationSettings.Locations)
                {
                    await locationsService.Create(new CreateLocationCommand(location, location));
                }
        }

    }
}
