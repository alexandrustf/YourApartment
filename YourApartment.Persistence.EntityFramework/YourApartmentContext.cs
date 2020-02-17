using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
