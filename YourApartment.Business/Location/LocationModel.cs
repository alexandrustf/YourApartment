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
            Id = location.Id;
            Name = location.Name;
            AdressLocation = location.AdressLocation.PreciseAdress;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string AdressLocation { get; private set; }
    }
}
