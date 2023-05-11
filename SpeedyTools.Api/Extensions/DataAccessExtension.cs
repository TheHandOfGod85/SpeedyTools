using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SpeedyTools.Application.Services.Implementations;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.DataAccess;
using SpeedyTools.DataAccess.Implementations;
using SpeedyTools.DataAccess.Implementations.Repositories;
using SpeedyTools.DataAccess.Interfaces;
using SpeedyTools.DataAccess.Interfaces.Repositories;
using SpeedyTools.Domain.Models.UserAggregate;

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
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }

        public static IServiceCollection AddDataContext(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                var connectionString = config.GetConnectionString("Default");
                options.UseSqlServer(connectionString);
            });
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
            return services;
        }
    }
}
