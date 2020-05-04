using EnsureThat;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public sealed class CreateApartmentCommand
    {
        public CreateApartmentCommand(string title, int price, int area, int numberOfRooms, int floor, int totalNumberOfFloors, 
            int numberOfBathRooms,
            Guid locationId, string exactAdress, string description, int confort, int constructionYear, double lat, double lng,
            byte[] imageBytes)
        {
            Title = title;
            Price = price;
            Area = area;
            NumberOfRooms = numberOfRooms;
            Floor = floor;
            TotalNumberOfFloors = totalNumberOfFloors;
            NumberOfBathRooms = numberOfBathRooms;
            LocationId = locationId;
            ExactAdress = exactAdress;
            Description = description;
            Confort = confort;
            ConstructionYear = constructionYear;
            Lat = lat;
            Lng = lng;
            ImageBytes = new List<byte[]>{imageBytes};
        }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public int TotalNumberOfFloors { get; set; }
        public int NumberOfBathRooms { get; set; }
        public Guid LocationId { get; set; }
        public string ExactAdress { get; set; }
        public string Description { get; set; }
        public int Confort { get; set; }
        public int ConstructionYear { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime AddedAt { get; set; }
        public IEnumerable<byte[]> ImageBytes { get; set; }

    }
}
