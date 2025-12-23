using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Infrastructure.Context;
using TestApp.Infrastructure.Repositories.Entities;
using TestApp.Infrastructure.Repositories.Generic;
using TestApp.Infrastructure.Repositories.Interfaces.Entities;
using TestApp.Infrastructure.Repositories.Interfaces.Generic;

namespace TestApp.Infrastructure.Extensions
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 01/02/2025
    /// Class: InfrastructureExtensions
    /// </summary>
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<IGendersRepository, GendersRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddDbContext<TestAppDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:TestAppDb"]));
            return services;
        }
    }
}
