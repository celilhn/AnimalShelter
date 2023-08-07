using Application.Interfaces;
using Application.Logging;
using Application.Services;
using Application.Models;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Notifications;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Utilities;
using AutoMapper;

namespace Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration _configuration)
        {
            Configuration configuration = _configuration.Get<Configuration>();
            services.AddSingleton(configuration);
            services.AddDbContext<AnimalShelterDbContext>(options =>
            options.UseSqlServer(configuration.DBConnectionText), ServiceLifetime.Transient);

            services.AddScoped<IHttpUtilities, HttpUtilities>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IApiLogger, ApiLogger>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IUserApplicationRepository, UserApplicationRepository>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
