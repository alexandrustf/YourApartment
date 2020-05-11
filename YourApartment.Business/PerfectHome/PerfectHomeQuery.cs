using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourApartment.Business
{
    public class PerfectHomeQuery
    {
        public PerfectHomeQuery(IEnumerable<double> latFavoriteLocations, IEnumerable<double> lngFavoriteLocations, bool nearMall, bool nearHospital, int numberOfRooms, int maxPrice)
        {
            this.FavoriteLocations = new List<Tuple<double, double>>();
            for (var i = 0; i < latFavoriteLocations.Count(); i++)
            {
                this.FavoriteLocations.Add(
                    new Tuple<double, double>(latFavoriteLocations.ElementAt(i), lngFavoriteLocations.ElementAt(i))
                    );
            }
            NearMall = nearMall;
            NearHospital = nearHospital;
            NumberOfRooms = numberOfRooms;
            MaxPrice = maxPrice;
        }

        public ICollection<Tuple<double, double>> FavoriteLocations { get; set; }
        public bool NearMall { get; set; }
        public bool NearHospital { get; set; }
        public int NumberOfRooms { get; set; }
        public int MaxPrice { get; set; }
    }
}
