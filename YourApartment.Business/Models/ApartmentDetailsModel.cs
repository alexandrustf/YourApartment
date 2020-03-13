using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public sealed class ApartmentDetailsModel
    {
        public ApartmentDetailsModel(Apartment apartment)
        {
            Id = apartment.Id;
            Title = apartment.Title;
            Price = apartment.Price;
            Area = apartment.Area;
            NumberOfRooms = apartment.NumberOfRooms;
            Floor = apartment.Floor;
            Confort = apartment.Confort;
            ConstructionYear = apartment.ConstructionYear;
            AddedAt = apartment.AddedAt;

        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public int Confort { get; set; }
        public int ConstructionYear { get; set; }
        public DateTime AddedAt { get; set; }

    }
}
