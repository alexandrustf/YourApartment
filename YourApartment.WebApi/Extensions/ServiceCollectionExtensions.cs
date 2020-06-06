using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourApartment.Domain;

namespace YourApartment.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Auth API",
                });


                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                });

                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return services;
        }

        public static IServiceCollection AddGeneralConfiguration(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            return services;
        }

        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            return services;
        }

        public static IServiceCollection AddDefaultLocationCollection(this IServiceCollection services)
        {
            return services.AddSingleton(provider =>
            {
                var config = provider.GetService<IConfiguration>();

                var defaultLocationCollection = config.GetSection(nameof(DefaultLocationCollection))
                    .GetChildren()
                    .ToList()
                    .Select(d => new DefaultLocationSettings(
                        d[nameof(DefaultLocationSettings.Location)]));

                return defaultLocationCollection.ToList();
            });
        }

    }
}
