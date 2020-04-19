using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework.Configurations
{
    public class UserApartmentConfiguration : IEntityTypeConfiguration<UserApartment>
    {
        public void Configure(EntityTypeBuilder<UserApartment> builder)
        {
            builder.HasKey(ua => new { ua.UserId, ua.ApartmentId });

            builder.HasOne(ua => ua.User)
                .WithMany(c => c.FavoriteApartments)
                .HasForeignKey(bc => bc.ApartmentId);

            builder.HasOne(ua => ua.Apartment)
                .WithMany(a => a.FavoriteForUsers)
                .HasForeignKey(ua => ua.UserId);
        }

    }
}
