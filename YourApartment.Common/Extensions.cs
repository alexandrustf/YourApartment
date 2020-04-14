using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YourApartment.Common
{
    public static class Extensions
    {
        public static IServiceCollection AddSettings<TSettings>(this IServiceCollection services)
            where TSettings : class
        {
            var instance = Activator.CreateInstance(typeof(TSettings), true);
            var properties = typeof(TSettings).GetProperties()
                .Where(p => p.CanWrite);

            return services.AddSingleton(provider =>
            {
                var configuration = provider.GetService<IConfiguration>()
                    .GetSection(typeof(TSettings).Name);
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(instance, int.Parse(configuration[property.Name]));
                    }
                    else
                    {
                        property.SetValue(instance, configuration[property.Name]);
                    }
                }

                return instance as TSettings;
            });
        }
    }
}
