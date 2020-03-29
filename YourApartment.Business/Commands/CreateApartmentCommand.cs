using EnsureThat;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public sealed class CreateApartmentCommand
    {
        public CreateApartmentCommand(string title, int price, int area, int numberOfRooms, int floor, int totalNumberOfFloors, 
            string reper, string adress, string description, int confort, int constructionYear,  
            IEnumerable<byte[]> imageBytes)
        {
            Title = title;
            Price = price;
            Area = area;
            NumberOfRooms = numberOfRooms;
            Floor = floor;
            TotalNumberOfFloors = totalNumberOfFloors;
            Reper = reper;
            Adress = adress;
            Description = description;
            Confort = confort;
            ConstructionYear = constructionYear;
            ImageBytes = imageBytes;
        }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public int TotalNumberOfFloors { get; set; }
        public string Reper { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public int Confort { get; set; }
        public int ConstructionYear { get; set; }
        public DateTime AddedAt { get; set; }
        public IEnumerable<byte[]> ImageBytes { get; set; }
    }
}
