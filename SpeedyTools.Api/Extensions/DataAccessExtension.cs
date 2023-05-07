using Microsoft.EntityFrameworkCore;
using SpeedyTools.DataAccess;
using SpeedyTools.DataAccess.Repositories;
using SpeedyTools.DataAccess.Repositories.Implementations;
using SpeedyTools.DataAccess.Units;
using SpeedyTools.DataAccess.Units.Implementations;

namespace SpeedyTools.Api.Extensions
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddUnitsOfWork(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository,Repository>();
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
