using CSharpFunctionalExtensions;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourApartment.Domain;

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

        public Task<Result> Create(CreateAccommodationCommand command)
        {
            EnsureArg.IsNotNull(command);
            return Result.Success( Apartment.Create(command.Title))
                .OnSuccess(s => writeRepository.Create(s.Value))
                .OnSuccess(_ => writeRepository.Commit())
                .OnSuccess(s => Result.Success());
        }

        public async Task<Result<IEnumerable<Apartment>>> GetAll(GetAccommodationsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
