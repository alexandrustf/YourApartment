using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public sealed class AccommodationModel
    {
        public AccommodationModel(Apartment apartment)
        {
            Id = apartment.Id;
            Title = apartment.Title;
            Price = apartment.Price;
            Area = apartment.Area;
            NumberOfRooms = apartment.NumberOfRooms;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
