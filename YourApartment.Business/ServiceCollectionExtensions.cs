using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourApartment.Business.Users;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IApartmentsService, ApartmentsService>();
            services.AddScoped<ILocationsService, LocationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPerfectHomeService, PerfectHomeService>();

            return services;
        }



        public static User WithoutPassword(this User user)
        {
            return user;
        }
    }
}
