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

            mapper.Property<Apartment>(s => s.PartitioningType)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.PartitioningType));

            mapper.Property<Apartment>(s => s.TotalNumberOfFloors)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.TotalNumberOfFloors));

            mapper.Property<Apartment>(s => s.PostedBy)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.PostedBy));

            mapper.Property<Apartment>(s => s.PostedFor)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.PostedFor));

            mapper.Property<Apartment>(s => s.Description)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.Description));

            mapper.Property<Apartment>(s => s.Location.Id)
                .CanFilter()
                .CanSort()
                .HasName(nameof(Apartment.Location));

            mapper.Property<Apartment>(s => s.Location.Name)
                .CanFilter()
                .CanSort()
                .HasName("LocationName");

            // TODO ALL PROPERTIES TO BE ADDED!
        }
    }
}
