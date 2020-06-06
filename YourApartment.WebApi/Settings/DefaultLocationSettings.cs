using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourApartment.WebApi
{
    public class DefaultLocationSettings
    {
        public DefaultLocationSettings(string location)
        {
            Location = location;
        }
        public string Location { get; set; }
    }
}
