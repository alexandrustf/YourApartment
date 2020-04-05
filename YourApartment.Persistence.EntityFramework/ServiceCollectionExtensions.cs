using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;
using YourApartment.Persistence.EntityFramework.Repositories;

namespace YourApartment.Persistence.EntityFramework
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<YourApartmentContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ApartmentsReadRepository<>));
            services.AddScoped<IReadRepository<Apartment>, ApartmentsReadRepository<Apartment>>();
            services.AddScoped<IReadRepository<Location>, LocationReadRepository>();
            services.AddScoped<IWriteRepository<Apartment>, WriteRepository<Apartment>>();
            services.AddScoped<IWriteRepository<Location>, WriteRepository<Location>>();

            return services;
        }
    }
}
