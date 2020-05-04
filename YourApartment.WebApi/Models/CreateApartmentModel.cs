using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YourApartment.WebApi
{
    public class CreateApartmentModel
    {
        public string Title { get; set; }
        public int Price { get;  set; }
        public int Area { get;  set; }
        public int NumberOfRooms { get;  set; }
        public int Floor { get;  set; }
        public int TotalNumberOfFloors { get;  set; }
        public int NumberOfBathRooms { get; set; }
        public Guid LocationId { get;  set; }
        public string ExactAdress { get;  set; }
        public string Description { get;  set; }
        public int Confort { get;  set; }
        public int ConstructionYear { get;  set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public byte[] ImagesBytes { get; set; }
    }
}
