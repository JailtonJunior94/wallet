using Serilog;
using Transaction.Domain.Handlers;
using Microsoft.Extensions.Hosting;
using Transaction.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Transaction.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IReceiverMessageHandle, ReceiverMessageHandle>();
                    services.AddHostedService<Worker>();

                    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(hostContext.Configuration)
                   .CreateLogger();
                }).UseSerilog();
    }
}
