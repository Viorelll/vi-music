using ViMusic.Application.Common.Interfaces;
using ViMusic.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
// using NSwag;
// using NSwag.Generation.Processors.Security;
using ZymLabs.NSwag.FluentValidation;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddScoped<FluentValidationSchemaProcessor>(provider =>
        {
            var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
            var loggerFactory = provider.GetService<ILoggerFactory>();

            return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
        });

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddOpenApiDocument((configure, serviceProvider) =>
        {
            var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

            // Add the fluent validations schema processor
            configure.SchemaSettings.SchemaProcessors.Add(fluentValidationSchemaProcessor);

            configure.Title = "ViMusic API";
            // configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            // {
            //     Type = OpenApiSecuritySchemeType.ApiKey,
            //     Name = "Authorization",
            //     In = OpenApiSecurityApiKeyLocation.Header,
            //     Description = "Type into the textbox: Bearer {your JWT token}."
            // });

            // configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });

        return services;
    }
}
