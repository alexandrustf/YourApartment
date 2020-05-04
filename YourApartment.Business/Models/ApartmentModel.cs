using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public sealed class ApartmentModel
    {
        public ApartmentModel()
        {
        }
        public ApartmentModel(Apartment apartment, IEnumerable<byte[]> images)
        {
            Id = apartment.Id;
            Title = apartment.Title;
            Price = apartment.Price;
            Area = apartment.Area;
            NumberOfRooms = apartment.NumberOfRooms;
            Location = apartment.Location.Name;
            ExactAdress = apartment.ExactAdress;
            Images = images;
            Latitude = apartment.Latitude;
            Longitude = apartment.Longitude;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public int Price { get; private set; }
        public int Area { get; private set; }
        public int NumberOfRooms { get; private set; }
        public string Location { get; private set; }
        public string ExactAdress { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude{ get; private set; }
        
        public IEnumerable<byte[]> Images { get; set; }

    }
}
