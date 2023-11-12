
using CrossmintChallenge.Application.Services;
using CrossmintChallenge.Core.Interfaces.Proxies;
using CrossmintChallenge.Core.Interfaces.Services;
using CrossmintChallenge.Infrstructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossmintChallenge.Application.ExtensionMethods;

public static class ConfigureServices
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IGoalService, GoalService>();
        services.AddScoped<IGoalProxy, GoalProxy>();
        services.AddScoped<IMegaverseService, MegaverseService>();

        return services;
    }
}
