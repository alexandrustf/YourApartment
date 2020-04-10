using System;
using System.Collections.Generic;
using System.Text;
using EnsureThat;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public class LocationModel
    {
        public LocationModel(Location location)
        {
            EnsureArg.IsNotNull(location);
            Name = location.Name;
            AdressLocation = location.AdressLocation.PreciseAdress;
        }
        public string Name { get; private set; }
        public string AdressLocation { get; private set; }
    }
}
