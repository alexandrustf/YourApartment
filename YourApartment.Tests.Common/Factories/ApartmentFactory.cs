using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Tests.Common.Factories
{
    public static class ApartmentFactory
    {
        public static Apartment GetApartment(string title, string adress, int area, int confort, int constructionYear, int numberOfRooms, int price, string description, int floor, string reper, int totalNumberOfFloors)
        {
            return Apartment.Create(title, adress, area, numberOfRooms, floor, totalNumberOfFloors, price, adress, floor, reper, constructionYear).Value;
        }
    }
}
