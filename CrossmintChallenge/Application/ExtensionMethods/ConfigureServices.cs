﻿using CrossmintChallenge.Application.Services;
using CrossmintChallenge.Core.Interfaces.Proxies;
using CrossmintChallenge.Core.Interfaces.Services;
using CrossmintChallenge.Infrstructure;
using CrossmintChallenge.Infrstructure.Proxies;
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

        return services;
    }
}