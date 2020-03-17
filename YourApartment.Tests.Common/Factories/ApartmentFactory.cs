using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Tests.Common.Factories
{
    public static class ApartmentFactory
    {
        public static Apartment GetApartment(string title)
        {
            return Apartment.Create(title).Value;
        }
    }
}
