using CrossmintChallenge.Application.Services;
using CrossmintChallenge.Core.Interfaces.Proxies;
using CrossmintChallenge.Core.Interfaces.Services;
using CrossmintChallenge.Infrastructure.Proxies;
using Microsoft.Extensions.DependencyInjection;

namespace CrossmintChallenge.Application.ExtensionMethods;

public static class ConfigureServices
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IGoalService, GoalService>();
        services.AddScoped<IMegaverseService, MegaverseService>();
        services.AddScoped<IGoalProxy, GoalProxy>();
        services.AddScoped<IPolyanetProxy, PolyanetProxy>();
        services.AddScoped<ISoloonProxy, SoloonProxy>();
        services.AddScoped<IComethProxy, ComethProxy>();
        services.AddScoped<IAstralObjectProxy, AstralObjectProxy>();

        return services;
    }
}
