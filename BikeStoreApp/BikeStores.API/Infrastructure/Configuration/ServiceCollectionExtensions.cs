using BikeStores.Domain.Repositories;
using BikeStores.Domain.Session;
using BikeStores.Persistence;
using BikeStores.Persistence.Repositories;
using BikeStores.Services;
using BikeStores.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace BikeStores.API.Infrastructure.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUserData(this IServiceCollection services)
        {
            services.AddScoped<UserData>(srv =>
            {
                var identity = srv.GetService<IHttpContextAccessor>().HttpContext?.User?.Identity;
                return (identity != null)
                    ? new UserData()
                    {
                        Username = !string.IsNullOrEmpty(identity.Name)
                            ? identity.Name
                            : "anonymous",
                        IsAuthenticated = identity.IsAuthenticated
                    }
                    : new UserData()
                    {
                        Username = "anonymous",
                        IsAuthenticated = false
                    };
            });
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddDbContext<RepositoryDbContext>(builder =>
            {
                var connectionString = configuration.GetConnectionString("BikeStoresDatabase");

                builder.UseSqlServer(connectionString, options =>
                {
                    options.MigrationsAssembly("BikeStores.API");
                });
                builder.UseLazyLoadingProxies();
            });
        }
    }
}
