using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework.Configurations
{
    public class PreciseLocationConfiguration : IEntityTypeConfiguration<PreciseLocation>
    {
        public void Configure(EntityTypeBuilder<PreciseLocation> builder)
        {
            builder.HasKey(pl => pl.PreciseAdress);
        }
    }
}
