using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public sealed class ApartmentDetailsModel
    {
        public ApartmentDetailsModel(Apartment apartment, IEnumerable<byte[]> images)
        {
            Id = apartment.Id;
            Title = apartment.Title;
            Price = apartment.Price;
            Area = apartment.Area;
            NumberOfRooms = apartment.NumberOfRooms;
            Floor = apartment.Floor;
            TotalNumberOfFloors = apartment.TotalNumberOfFloors;
            Location = apartment.Location.Name;
            // ExactAdress = apartment.ExactAdress.PreciseAdress;
            Description = apartment.Description;
            Confort = apartment.Confort;
            ConstructionYear = apartment.ConstructionYear;
            AddedAt = apartment.AddedAt;
            Images = images;
        }

        public Guid Id { get; set; }
        public string Title { get; private set; }
        public int Price { get; private set; }
        public int Area { get; private set; }
        public int NumberOfRooms { get; private set; }
        public int Floor { get; private set; }
        public int TotalNumberOfFloors { get; private set; }
        public string Location { get; private set; }
        // public string ExactAdress { get; private set; }
        public string Description { get; private set; }
        public int Confort { get; private set; }
        public int ConstructionYear { get; private set; }
        public DateTime AddedAt { get; private set; }
        public IEnumerable<byte[]> Images { get; private set; }

    }
}
