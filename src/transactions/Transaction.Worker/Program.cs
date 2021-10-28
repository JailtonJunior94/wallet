using Serilog;
using Microsoft.Extensions.Hosting;
using Transaction.Worker.Configurations;
using Microsoft.Extensions.Configuration;
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
                    var builder = new ConfigurationBuilder()
                         .SetBasePath(hostContext.HostingEnvironment.ContentRootPath)
                         .AddJsonFile("appsettings.json", true, true)
                         .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true, true)
                         .AddEnvironmentVariables();

                    IConfiguration configuration = builder.Build();

                    services.AddDependencies();
                    services.AddLogger(configuration);
                    services.AddHostedService<Worker>();

                }).UseSerilog();
    }
}
