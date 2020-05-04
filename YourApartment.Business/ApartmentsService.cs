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
        private readonly IReadRepository<Location> readLocationRepository;
        private readonly IPaginationService<Apartment, ApartmentModel> paginationService;
        private readonly IImageRepository imageRepository;


        public ApartmentsService(IWriteRepository<Apartment> writeRepository, 
            IReadRepository<Apartment> readRepository, 
            IReadRepository<Location> readLocationRepository,
            IPaginationService<Apartment, ApartmentModel> paginationService, 
            IImageRepository imageRepository)
        {
            EnsureArg.IsNotNull(readRepository);
            EnsureArg.IsNotNull(writeRepository);
            EnsureArg.IsNotNull(paginationService);
            EnsureArg.IsNotNull(imageRepository);
            EnsureArg.IsNotNull(readLocationRepository);

            this.readLocationRepository = readLocationRepository;
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.paginationService = paginationService;
            this.imageRepository = imageRepository;
        }

        public async Task<Result> Create(CreateApartmentCommand command)
        {
            EnsureArg.IsNotNull(command);

            var adressResult = (await readLocationRepository.GetById(command.LocationId))
                .ToResult("Location does not exist!");

            return await Result.FirstFailureOrSuccess(adressResult)
                .Map(() => Apartment.Create(command.Title, adressResult.Value, command.ExactAdress, command.Area, command.Confort,
                    command.ConstructionYear, command.NumberOfRooms, command.Price,
                    command.Description, command.Floor, command.TotalNumberOfFloors,
                    command.NumberOfBathRooms, command.Lat, command.Lng).Value)
                .Tap(s => writeRepository.Create(s))
                .Tap(s => imageRepository.AddImage(s.Id, command.ImageBytes))
                .Tap(a => imageRepository.SaveChanges())
                .Tap(_ => writeRepository.Commit());
        }

        public async Task<PageModel<ApartmentModel>> GetAll(SieveQuery query)
        {
            EnsureArg.IsNotNull(query);
            var page = paginationService.GetPage(query.Model);

            return page;
        }

        public async Task<Result<ApartmentDetailsModel>> GetDetailedById(GetSpecifiedApartmentQuery query)
        {
            EnsureArg.IsNotNull(query);
            return (await readRepository.GetById(query.AccommodationId))
                .ToResult("Accommodation not found")
                .Map(a => new ApartmentDetailsModel(a, imageRepository.GetImagesForApartment(a.Id).Result));// CAn be implemented with AUTO mapper
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
                .Tap(a => a.Update(command.Title)) 
                .Tap(_ => writeRepository.Commit());
        }
    }
}
