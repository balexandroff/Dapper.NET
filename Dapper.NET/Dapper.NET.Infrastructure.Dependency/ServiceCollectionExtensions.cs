using Dapper.NET.Application.Interfaces;
using Dapper.NET.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;
using System.Text;
using MediatR;

namespace Dapper.NET.Infrastructure.Data.Dependency
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            var repoTypes = Assembly.Load(typeof(Repositories.CountryRepository).Assembly.GetName())
                          .GetTypes()
                          .Where(x => !string.IsNullOrEmpty(x.Namespace))
                          .Where(x => x.IsClass)
                          .Where(x => typeof(IRepository).IsAssignableFrom(x))
                          .Select(x => new
                          {
                              Interface = x.GetInterface($"I{x.Name}"),
                              Implementation = x
                          })
                          .ToList();

            foreach (var repoType in repoTypes)
            {
                services.AddScoped(repoType.Interface, repoType.Implementation);
            }

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var serviceTypes = Assembly.Load(typeof(Application.Services.CountryService).Assembly.GetName())
                          .GetTypes()
                          .Where(x => !string.IsNullOrEmpty(x.Namespace))
                          .Where(x => x.IsClass)
                          .Where(x => typeof(IService).IsAssignableFrom(x))
                          .Select(x => new
                          {
                              Interface = x.GetInterface($"I{x.Name}"),
                              Implementation = x
                          })
                          .ToList();

            foreach (var serviceType in serviceTypes)
            {
                services.AddScoped(serviceType.Interface, serviceType.Implementation);
            }

            services.AddMediatR(typeof(Dapper.NET.Application.Common.ServiceResult).Assembly);

            return services;
        }

        public static IServiceCollection RegisterIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StocksIdentityDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("StocksIdentityConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<StocksIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Key"]))
                };
            });

            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StocksDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("StocksConnection")));

            return services;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitecture", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.ViewModels.MapperProfiles.StockProfile),
                typeof(Application.ViewModels.MapperProfiles.CountryProfile));

            return services;
        }

        public static IApplicationBuilder UseSwaggerWithUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture v1"));

            return app;
        }
    }
}
