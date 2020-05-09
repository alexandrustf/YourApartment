using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public class PerfectHomeQuery
    {
        public PerfectHomeQuery(IEnumerable<Tuple<double, double>> favoriteLocations, bool nearMall, bool nearHospital, int maxPrice)
        {
            FavoriteLocations = favoriteLocations;
            NearMall = nearMall;
            NearHospital = nearHospital;
            MaxPrice = maxPrice;
        }

        public IEnumerable<Tuple<double, double>> FavoriteLocations { get; set; }
        public bool NearMall { get; set; }
        public bool NearHospital { get; set; }
        public int MaxPrice { get; set; }
    }
}
