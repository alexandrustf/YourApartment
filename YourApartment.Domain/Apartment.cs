using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Domain
{
    public class Apartment : Entity
    {
        public Apartment(string title)
        {
            this.Title = title;
            this.AddedAt = DateTime.Now;
        }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public int Confort { get; set; }
        public int ConstructionYear { get; set; }
        public DateTime AddedAt { get; set; }

        public static Result<Apartment> Create(string title)
        {
            return Result.Success<Apartment>(new Apartment(title));
        }
    }
}
