using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Tests.Common.Factories
{
    public static class ApartmentFactory
    {
        public static Apartment GetApartment(string title, Location location, PreciseLocation exactAdress, int price,
            int area, int numberOfRooms, int floor, int totalNumberOfFloors,
            string description, int constructionYear, int confort, int numberOfBathrooms, float lat, float lng)
        {
            return Apartment.Create(title, location, exactAdress.PreciseAdress, area, confort, constructionYear, 
                numberOfRooms, price, description, floor, totalNumberOfFloors, numberOfBathrooms,lat, lng).Value;
        }
    }
}
