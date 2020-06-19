using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using EnsureThat;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public class PerfectHomeService : IPerfectHomeService
    {
        private readonly IMapRoute mapRoute;
        private readonly IReadRepository<Apartment> readRepository;
        private readonly IMapper mapper;

        public PerfectHomeService(IMapRoute mapRoute, IReadRepository<Apartment> readRepository, IMapper mapper)
        {
            EnsureArg.IsNotNull(mapRoute);
            EnsureArg.IsNotNull(readRepository);

            this.mapRoute = mapRoute;
            this.readRepository = readRepository;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<ApartmentModel>>> PerfectApartments(PerfectHomeQuery perfectHomeQuery)
        {
            EnsureArg.IsNotNull(perfectHomeQuery);
            
            var apartments = await readRepository.Find(a =>
                a.Price <= perfectHomeQuery.MaxPrice && a.NumberOfRooms == perfectHomeQuery.NumberOfRooms);

            // Get All distances to selected points according to Maps API
            var tasks = apartments.Select(a => mapRoute.GetTimeForRoutesAsync(a.Latitude,
                a.Longitude, perfectHomeQuery.FavoriteLocations));

            await Task.WhenAll(tasks); // Wait for all requests to be resolved

            if (tasks.Select(t => t.Result).Count(p => p.IsFailure) > 0)
                return Result.Failure<IEnumerable<ApartmentModel>>("There was a problem with Google Maps Request!");

            // Make sum of all routes
            var computedDistancesIntoOne = tasks.Select(t => t.Result.Value.Sum());
            
            var bestApartmentDistance = computedDistancesIntoOne.Min();
            var index = 0;

            // Filter only the apartments which are only 120% of the best route
            var distancesWithIndex = computedDistancesIntoOne.Select(p => new Tuple<int, int>(index++, p))
                .Where(p => p.Item2 / 1.2 <= bestApartmentDistance);

            var indexes = distancesWithIndex.Select(p => p.Item1);
            
            // Filter By the indexes in which the apartment respects the above formula
            var filteredApartments = apartments.Where((apartment, ind) =>
                indexes.Contains(ind));

            return Result.Ok(filteredApartments.Select(a => mapper.Map<Apartment, ApartmentModel>(a)));
        }
    }
}
