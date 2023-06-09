﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Api.Services.Implementations;
using SpeedyTools.Application.AppUsers.Commands;
using SpeedyTools.Application.Services.Implementations;
using SpeedyTools.Application.Services.Interfaces;
using SpeedyTools.Domain.Models.UserAggregate;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Api.Extensions
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<RegisterAppUserCommand>();
            });
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IEmailService, SendGridService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IApiContextAccessor, WebApiContextService>();
            services.AddScoped<IEncoderService, WebEncoderService>();
            services.AddScoped<IWebRootPathBuilder, WebRootPathBuilderService>();
            services.AddScoped<IHtmlProcessor, HtmlProcessor>();
            services.AddTransient<SampleData>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
                });
            });
            
            return services;
        }

        public static IServiceCollection AddDataContext(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                var connectionString = config.GetConnectionString("Default");
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<DataContext>()
              .AddSignInManager<SignInManager<AppUser>>()
              .AddDefaultTokenProviders();
            return services;
        }
    }
}
