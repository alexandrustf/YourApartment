using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Sieve.Services;
using YourApartment.Business;
using YourApartment.Common;
using YourApartment.Domain;

namespace YourApartment.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddTransient<ITokenProvider, JwtTokenProvider>()
                .AddSettings<JwtSettings>();
            return services.AddScoped(typeof(IPaginationService<,>), typeof(PaginationService<,>))
                .AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
        }
    }
}
