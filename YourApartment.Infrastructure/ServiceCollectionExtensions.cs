using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Sieve.Services;
using YourApartment.Business;

namespace YourApartment.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IPaginationService<,>), typeof(PaginationService<,>))
                .AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
        }
    }
}
