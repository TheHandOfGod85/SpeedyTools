using Microsoft.EntityFrameworkCore;
using SpeedyTools.DataAccess;
using SpeedyTools.DataAccess.Implementations;
using SpeedyTools.DataAccess.Implementations.Repositories;
using SpeedyTools.DataAccess.Interfaces;
using SpeedyTools.DataAccess.Interfaces.Repositories;

namespace SpeedyTools.Api.Extensions
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddUnitsOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            
            return services;
        }

        public static IServiceCollection AddDataContext(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                var connectionString = config.GetConnectionString("Default");
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
