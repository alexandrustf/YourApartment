using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace YourApartment.Business
{
    public class PerfectHomeService : IPerfectHomeService
    {
        private readonly IMapRoute mapRoute;
        public async Task<Result<IEnumerable<ApartmentModel>>> PerfectApartments(PerfectHomeQuery perfectHomeQuery)
        {
            var location = perfectHomeQuery.FavoriteLocations.FirstOrDefault();
            var lat = 47.143087753683261;
            var lng = 27.574567794799805;

            var result = await mapRoute.GetTimeForRoute(lat, lng, perfectHomeQuery.FavoriteLocations);
            var list = new List<ApartmentModel>() as IEnumerable<ApartmentModel>;
            return Result.Ok(list);
        }
    }
}
