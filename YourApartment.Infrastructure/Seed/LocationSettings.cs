using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Infrastructure
{
    public class LocationSettings
    {
        public LocationSettings(IEnumerable<string> locations)
        {
            Locations = locations;
        }
        public IEnumerable<string> Locations { get; set; }
    }
}
