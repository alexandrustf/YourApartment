using CSharpFunctionalExtensions;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourApartment.Domain;
using System.Linq;


namespace YourApartment.Business
{
    public class ServiceAccommodations : IServiceAccommodations
    {
        private readonly IReadRepository<Apartment> readRepository;
        private readonly IWriteRepository<Apartment> writeRepository;


        public ServiceAccommodations(IWriteRepository<Apartment> writeRepository, IReadRepository<Apartment> readRepository)
        {
            EnsureArg.IsNotNull(readRepository);
            EnsureArg.IsNotNull(writeRepository);

            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
        }

        public async Task<Result> Create(CreateAccommodationCommand command)
        {
            EnsureArg.IsNotNull(command);
            return await Result.Success(Apartment.Create(command.Title))
                .Tap(s => writeRepository.Create(s.Value))
                .Tap(_ => writeRepository.Commit());
        }

        public async Task<IEnumerable<AccommodationModel>> GetAll(GetAccommodationsQuery query)
        {
            var accommodations = await readRepository.GetAll();
            return accommodations.OrderBy(c => c.Title).Select(a => new AccommodationModel(a));
        }
    }
}
