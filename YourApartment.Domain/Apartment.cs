using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourApartment.Domain
{
    public class Apartment : Entity
    {
        private Apartment()
        {

        }
        public Apartment(string title, Location location, string exactAdress, int price, 
            int area, int numberOfRooms, int floor, int totalNumberOfFloors, 
            string description, int constructionYear, int confort)
        {
            Title = title;
            Price = price;
            Area = area;
            NumberOfRooms = numberOfRooms;
            Floor = floor;
            TotalNumberOfFloors = totalNumberOfFloors;
            Location = location;
            ExactAdress = exactAdress;
            Description = description;
            ConstructionYear = constructionYear;
            AddedAt = DateTime.Now;
        }
        public string Title { get; private set; }
        public int Price { get; private set; }
        public int Area { get; private set; }
        public int NumberOfRooms { get; private set; }
        public int Floor { get; private set; }
        public int TotalNumberOfFloors { get; private set; }
        public Location Location { get; private set; }

        public string ExactAdress { get; private set; }

        public string Description { get; private set; }
        public int Confort { get; private set; }
        public int ConstructionYear { get; private set; }

        public ApartmentEnums.PartitioningType PartitioningType { get; set; }
        public ApartmentEnums.PostedBy PostedBy { get; private set; }
        public ApartmentEnums.Building Building { get; private set; }
        public ApartmentEnums.PostedFor PostedFor { get; private set; }
        public DateTime AddedAt { get; private set; }

        public Result Update(string title)

        {
            this.Title = title;
            return Result.Ok();
        }
        public static Result<Apartment> Create(string title,Location location, string exactAdress, int area, int confort, int constructionYear, int numberOfRooms, int price, string description, int floor, int totalNumberOfFloors)
        {
            return Result.Success<Apartment>(new Apartment(title, location, exactAdress, price, area, numberOfRooms, floor, totalNumberOfFloors, description,  constructionYear, confort));
        }
    }
}
