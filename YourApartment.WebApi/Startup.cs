using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using YourApartment.Business;
using YourApartment.Infrastructure;
using YourApartment.Persistence.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace YourApartment.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors()
                .AddPersistence(Configuration.GetConnectionString("YourApartment"));
            services.AddControllers();


            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<JwtSettings>(appSettingsSection);
            var locationSettings = Configuration.GetSection("LocationSettings");
            services.Configure<LocationSettings>(locationSettings);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<JwtSettings>();
            
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddApiVersioning();
            services.AddAutoMapper(InfrastructureAssembly.Value);
            services.AddSwagger();
            services.AddBusiness();
            services.AddInfrastructure();
            services.AddMvc();
            services.AddDefaultLocationCollection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, List<DefaultLocationSettings> defaultLocations, ILocationsService locationsService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();
            app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseSwagger()
                .UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth"); options.RoutePrefix = string.Empty; });
            app.CreateDefaultLocation(defaultLocations, locationsService);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
        }
    }
}
