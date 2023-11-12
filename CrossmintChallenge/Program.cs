using CrossmintChallenge.Application.ExtensionMethods;
using CrossmintChallenge.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
                            .AddAppConfiguration()
                            .AddCustomServices()
                            .BuildServiceProvider();

// Use the service
var myService = serviceProvider.GetRequiredService<IGoalService>();
Console.WriteLine($"Current goal: {await myService.GetCurrentGoal()}");

Console.WriteLine("Hello, World!");
var input = Console.ReadLine();

Console.WriteLine(input);