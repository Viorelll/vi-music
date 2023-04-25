using ViMusic.Application.Common.Interfaces;
// using ViMusic.Infrastructure.Files;
using ViMusic.Infrastructure.Persistence;
using ViMusic.Infrastructure.Persistence.Interceptors;
using ViMusic.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ViMusicDb"));
        }
        if (configuration.GetValue<bool>("UseMsSqlDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MsSqlConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        if (configuration.GetValue<bool>("UsePostgresDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        if (configuration.GetValue<bool>("UseMySqlDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("MySqlConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        if (configuration.GetValue<bool>("UseUseCosmosDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseCosmos(configuration.GetConnectionString("CosmosConnection"), "ViMusicDb"));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<IDateTime, DateTimeService>();

        // services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        return services;
    }
}
