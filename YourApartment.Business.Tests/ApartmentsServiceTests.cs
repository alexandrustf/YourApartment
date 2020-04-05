using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using Xunit;
using YourApartment.Domain;
using YourApartment.Tests.Common;
using YourApartment.Tests.Common.Factories;

namespace YourApartment.Business.Tests
{
    public class ApartmentsServiceTests : BaseTest<IApartmentsService>
    {
        private Mock<IReadRepository<Apartment>> readRepositoryMock;
        private Mock<IWriteRepository<Apartment>> writeRepositoryMock;
        private Mock<IPaginationService<Apartment, ApartmentModel>> paginationMock;
        private Mock<IImageRepository> imageRepository;


        [Fact]
        public async Task Given_Create_When_ApartmentIsValid_Then_ShouldSucceed()
        {
            //Arrange
            var command = GetCreateApartmentCommand();
            var apartment = Result.Success();
            
            //Act
            var result = await SystemUnderTest.Create(command);
            

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        private CreateApartmentCommand GetCreateApartmentCommand()
            => new CreateApartmentCommand(
                "My new Apartment",
                300,
                75,
                3,
                2,
                4,
                "Pe sf. Lazar",
                "Sf. Lazar nr.5",
                "Foarte bine intretinut",
                8,
                1980,
                new List<byte[]>{ new byte[] { } });



        protected override void SetupMocks(MockRepository mockRepository)
        {
            readRepositoryMock = mockRepository.Create<IReadRepository<Apartment>>();
            writeRepositoryMock = MockWriteRepositoryFactory<Apartment>.Create(mockRepository);
            paginationMock = mockRepository.Create<IPaginationService<Apartment, ApartmentModel>>();
        }

        protected override IApartmentsService CreateSystemUnderTest()
            => new ApartmentsService(writeRepositoryMock.Object, readRepositoryMock.Object, paginationMock.Object, imageRepository.Object);

    }
}
