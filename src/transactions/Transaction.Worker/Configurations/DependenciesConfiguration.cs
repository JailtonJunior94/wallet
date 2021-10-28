using Transaction.Domain.Handlers;
using Transaction.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Transaction.Worker.Configurations
{
    public static class DependenciesConfiguration
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IReceiverMessageHandle, ReceiverMessageHandle>();
        }
    }
}
