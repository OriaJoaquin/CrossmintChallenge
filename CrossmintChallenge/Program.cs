using CrossmintChallenge.Application.Services;
using CrossmintChallenge.Core.Interfaces.Proxies;
using CrossmintChallenge.Core.Interfaces.Services;
using CrossmintChallenge.Infrstructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

string apiBaseUrl = configuration["AppSettings:APIBaseURL"];

// Set up DI container
var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration)
    .AddScoped<IGoalService, GoalService>()  
    .AddScoped<IGoalProxy, GoalProxy>()  
    .BuildServiceProvider();

// Use the service
var myService = serviceProvider.GetRequiredService<IGoalService>();
Console.WriteLine($"Current goal: {await myService.GetCurrentGoal()}");

Console.WriteLine(apiBaseUrl);

Console.WriteLine("Hello, World!");
var input = Console.ReadLine();

Console.WriteLine(input);