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
    public class ApartmentsService : IApartmentsService
    {
        private readonly IReadRepository<Apartment> readRepository;
        private readonly IWriteRepository<Apartment> writeRepository;
        private readonly IPaginationService<Apartment, ApartmentModel> paginationService;


        public ApartmentsService(IWriteRepository<Apartment> writeRepository, IReadRepository<Apartment> readRepository, IPaginationService<Apartment, ApartmentModel> paginationService)
        {
            EnsureArg.IsNotNull(readRepository);
            EnsureArg.IsNotNull(writeRepository);
            EnsureArg.IsNotNull(paginationService);

            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.paginationService = paginationService;
        }

        public async Task<Result> Create(CreateAparmentCommand command)
        {
            EnsureArg.IsNotNull(command);
            return await Result.Success(Apartment.Create(command.Title))
                .Tap(s => writeRepository.Create(s.Value))
                .Tap(_ => writeRepository.Commit());
        }

        public async Task<PageModel<ApartmentModel>> GetAll(SieveQuery query)
        {
            EnsureArg.IsNotNull(query);
            return paginationService.GetPage(query.Model);
        }

        public async Task<Result<ApartmentDetailsModel>> GetDetailedById(GetSpecifiedApartmentQuery query)
        {
            EnsureArg.IsNotNull(query);
            return (await readRepository.GetById(query.AccommodationId))
                .ToResult("Accommodation not found")
                .Map(a => new ApartmentDetailsModel(a));
        }

        public async Task<Result> DeleteById(DeleteApartmentByIdCommand command)
        {
            return await this.GetApartmentById(command.Id).ToResult("Accommodation Does Not Exist")
                .Tap(a => writeRepository.Delete(a))
                .Tap(_ => writeRepository.Commit());
        }

        private async Task<Maybe<Apartment>> GetApartmentById(Guid id) => (await readRepository.GetById(id));

        public async Task<Result> UpdateApartment(UpdateApartmentCommand command)
        {
            return await readRepository.GetById(command.Id)
                .ToResult("Accommodation not found")
                .Tap(a => a.Title = command.Title) // CAn be implemented with AUTO mapper
                .Tap(_ => writeRepository.Commit());
        }
    }
}
