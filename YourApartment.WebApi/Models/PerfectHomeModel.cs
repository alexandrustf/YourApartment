using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourApartment.WebApi.Models
{
    public class PerfectHomeModel
    {
        public IEnumerable<Tuple<double, double>> FavoriteLocations{ get; set; }
        public bool NearMall { get; set; }
        public bool NearHospital { get; set; }
        public int MaxPrice { get; set; }
    }
}
