using User.Domain.Services;
using User.Domain.Interfaces;
using User.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace User.API.Configurations
{
    public static class DependenciesConfiguration
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            /* Repositories */
            services.AddSingleton<IUserRepository, UserRepository>();

            /* Services */
            services.AddScoped<IUserService, UserService>();
        }
    }
}
