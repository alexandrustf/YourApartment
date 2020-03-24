using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public sealed class ApartmentModel
    {
        public ApartmentModel()
        {
                
        }
        public ApartmentModel(Apartment apartment)
        {
            Id = apartment.Id;
            Title = apartment.Title;
            Price = apartment.Price;
            Area = apartment.Area;
            NumberOfRooms = apartment.NumberOfRooms;
            Reper = apartment.Landmark;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int NumberOfRooms { get; set; }
        public string Reper { get; set; }
    }
}
