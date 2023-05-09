using Microsoft.EntityFrameworkCore;
using SpeedyTools.DataAccess;
using SpeedyTools.DataAccess.Repositories;
using SpeedyTools.Domain.Interfaces.Repositories;

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
            services.AddScoped<IAppUserRepository, AppUserRepository>();
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
