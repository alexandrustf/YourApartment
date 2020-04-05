using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework
{
    public sealed class YourApartmentContext : DbContext
    {
        public YourApartmentContext(DbContextOptions options)
        : base(options)
        {
        }
        private YourApartmentContext()
        {
        }
        public DbSet<Apartment> Apartments { get; private set; }
        public DbSet<Location> Locations { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configurations = typeof(YourApartmentContext)
                .Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .Select(Activator.CreateInstance);

            foreach (var configuration in configurations)
            {
                modelBuilder.ApplyConfiguration((dynamic)configuration);
            }
        }
    }
}
