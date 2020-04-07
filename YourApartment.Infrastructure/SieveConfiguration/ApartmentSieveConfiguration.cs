using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Infrastructure.SieveConfiguration
{
    internal sealed class ApartmentSieveConfiguration : ISieveEntityConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Apartment>(s => s.Title)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.Title));

            mapper.Property<Apartment>(s => s.Price)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.Price));

            mapper.Property<Apartment>(s => s.Floor)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.Floor));

            mapper.Property<Apartment>(s => s.NumberOfRooms)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.NumberOfRooms));

            mapper.Property<Apartment>(s => s.Confort)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.Confort));

            mapper.Property<Apartment>(s => s.ConstructionYear)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.ConstructionYear));

            mapper.Property<Apartment>(s => s.Area)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.Area));


            // TODO ALL PROPERTIES TO BE ADDED!
        }
    }
}
