using CrossmintChallenge.Application.ExtensionMethods;
using CrossmintChallenge.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
                            .AddAutoMapper()
                            .AddAppConfiguration()
                            .AddCustomServices()
                            .BuildServiceProvider();

var goalService = serviceProvider.GetRequiredService<IGoalService>();
var megaverseService = serviceProvider.GetRequiredService<IMegaverseService>();

var currentGoal = await goalService.GetCurrentGoal();

await megaverseService.CreateMegaverse(currentGoal);