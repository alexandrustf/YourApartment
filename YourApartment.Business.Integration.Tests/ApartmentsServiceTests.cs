using YourApartment.Domain;
using YourApartment.Tests.Common.Stubs;
using YourApartment.Persistence.EntityFramework;

namespace YourApartment.Business.Integration.Tests
{
    public class ApartmentsServiceTests
    {
        private readonly IReadRepository<Apartment> readRepository;
        private readonly IWriteRepository<Apartment> writeRepository;
        private readonly IPaginationService<Apartment, ApartmentModel> paginationService;

        private ApartmentsService sut;

        public ApartmentsServiceTests()
        {
            var context = ContextFactory.BuildContext();
            //this.readRepository = new ApartmentsReadRepository(context);
            //this.writeRepository = new WriteRepository<Apartment>(context);
            //this.paginationService = paginationService;
            //this.sut = sut;
        }
    }
}