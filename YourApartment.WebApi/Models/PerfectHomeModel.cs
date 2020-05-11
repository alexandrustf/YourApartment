using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourApartment.WebApi.Models
{
    public class PerfectHomeModel
    {
        public IEnumerable<double> LatFavoriteLocations{ get; set; }

        public IEnumerable<double> LngFavoriteLocations { get; set; }

        public bool NearMall { get; set; }
        public bool NearHospital { get; set; }
        public int NumberOfRooms { get; set; }
        public int MaxPrice { get; set; }
    }
}
