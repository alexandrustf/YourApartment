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
            ExactAdress = apartment.ExactAdress;
            Description = apartment.Description;
            Confort = apartment.Confort;
            ConstructionYear = apartment.ConstructionYear;
            NumberOfBathrooms = apartment.NumberOfBathrooms;
            PartitioningType = apartment.PartitioningType.ToString();
            PostedBy = apartment.PostedBy.ToString();
            Building = apartment.Building.ToString();
            AddedAt = apartment.AddedAt;
            Latitude = apartment.Latitude;
            Longitude = apartment.Longitude;
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
        public string ExactAdress { get; private set; }
        public string Description { get; private set; }
        public int Confort { get; private set; }
        public int ConstructionYear { get; private set; }
        public int NumberOfBathrooms { get; private set; }
        public string PartitioningType { get; private set; }
        public string PostedBy { get; private set; }
        public string Building { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime AddedAt { get; private set; }
        public IEnumerable<byte[]> Images { get; private set; }

    }
}
