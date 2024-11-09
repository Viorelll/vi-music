using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ViMusic.Infrastructure.Persistence;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Set up configuration to read from appsettings.json
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables() // Optionally add environment variables
            .Build();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddApplicationServices();
                services.AddInfrastructureServices(context.Configuration);
            })
            .Build();

        // Apply migrations at startup
        using (var scope = host.Services.CreateScope())
        {
            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
            await initialiser.InitialiseAsync();
            await initialiser.SeedAsync();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("All migrations have been applied.");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}