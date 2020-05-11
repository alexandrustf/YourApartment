using System;
using System.Collections.Generic;
using System.Linq;
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

            var tasks = apartments.Select(a => mapRoute.GetTimeForRoutesAsync(a.Latitude,
                a.Longitude, perfectHomeQuery.FavoriteLocations));

            await Task.WhenAll(tasks);

            var results = tasks.Select(t => t.Result);

            int index = 0;
            var resultsTuple = new List<Tuple<int, int>>();
            foreach (var res in results)
            {
                resultsTuple.Add(new Tuple<int, int>(index, res.Sum()));
                index++;
            }
            var resultsOrdered = resultsTuple.OrderBy(p => p.Item2);

            var best = resultsOrdered.FirstOrDefault();
            var resultsFiltered = resultsOrdered.Where(p => p.Item2 / 1.2 <= best.Item2);

            var filteredApartments = new List<Apartment>();
            var j = 0;
            foreach (var apartment in apartments)
            {
                if (resultsFiltered.Select(p => p.Item1).Contains(j))
                {
                    filteredApartments.Add(apartment);
                }
                j++;
            }

            return Result.Ok(filteredApartments.Select(a => mapper.Map<Apartment, ApartmentModel>(a)));
        }
    }
}
