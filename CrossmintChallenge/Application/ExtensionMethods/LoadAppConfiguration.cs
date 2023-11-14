using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossmintChallenge.Application.ExtensionMethods;

public static class LoadAppConfiguration
{
    public static IServiceCollection AddAppConfiguration(this IServiceCollection services)
    {
        IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

        services.AddSingleton(configuration);

        return services;
    }
}
