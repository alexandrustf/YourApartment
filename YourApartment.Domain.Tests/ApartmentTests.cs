using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;
using YourApartment.Tests.Common.Factories;

namespace YourApartment.Domain.Tests
{
    public class ApartmentTests
    {
        [Theory]
        [InlineData("Apartament misto")]
        [InlineData("adsadsa as2313")]
        public void Given_Create_When_ApartmentIsValid_Then_ShouldSucceed(string name)
        {
            //Arrange
            var apartment = ApartmentFactory.GetApartment(name);

            //Act
            var result = Apartment.Create(name);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
