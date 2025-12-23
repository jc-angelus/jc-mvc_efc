using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Application.Interfaces;
using TestApp.Application.Services;
using TestApp.Domain.Mappers;
using TestApp.Infrastructure.Extensions;
using TestApp.Infrastructure.Repositories.Generic;
using TestApp.Infrastructure.Repositories.Interfaces.Generic;
using System.Reflection;

namespace TestApp.Application.Extensions
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: ApplicationExtensions
    /// </summary>
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();            
            services.AddAutoMapper(typeof(DomainMappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());            
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IGendersServices, GendersServices>();
            services.AddScoped<IMaritalStatusServices, MaritalStatusServices>();
            services.AddScoped<IClientsServices, ClientsServices>();
            InfrastructureExtensions.AddInfrastructure(services, configuration);            
            return services;
        }

    }
}
