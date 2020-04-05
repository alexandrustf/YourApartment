using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using EnsureThat;
using YourApartment.Common;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public class LocationService : ILocationsService
    {
        private readonly IReadRepository<Location> readRepository;
        private readonly IWriteRepository<Location> writeRepository;
        
        public LocationService(IReadRepository<Location> readRepository, IWriteRepository<Location> writeRepository)
        {
            EnsureArg.IsNotNull(readRepository);
            EnsureArg.IsNotNull(writeRepository);

            this.readRepository = readRepository;
            this.writeRepository = writeRepository; 
        }

        public async Task<Result> Create(CreateLocationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var name = command.Name.NullOrValid();
            var adress = command.PreciseAdress.NullOrValid();

            var duplicateLocationByName = (await readRepository.FindOne(l => l.Name.ToLower() == command.Name.ToLower() ))
                .ToInverseResult("Location Already Exists");

            return await Result.FirstFailureOrSuccess(duplicateLocationByName)
                .Map(() => PreciseLocation.Create(adress))
                .Map(pa => Location.Create(name, pa.Value))
                .Tap(l => writeRepository.Create(l.Value))
                .Tap(_ => writeRepository.Commit());
        }

        public async Task<IEnumerable<LocationModel>> GetAll()
            => (await readRepository.GetAll()).OrderBy(s => s.Name).Select(l => new LocationModel(l));
    }
}