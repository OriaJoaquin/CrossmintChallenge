using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Interfaces.Proxies;
using CrossmintChallenge.Core.Interfaces.Services;
using System.Buffers.Text;
using System.Threading.Tasks;
using System;
using CrossmintChallenge.Infrstructure.Proxies;
using CrossmintChallenge.Application.Helpers;

namespace CrossmintChallenge.Application.Services;

public class MegaverseService : IMegaverseService
{
    private readonly IPolyanetProxy _polyanetProxy;

    public MegaverseService(IPolyanetProxy polyanetProxy)
    {
        _polyanetProxy = polyanetProxy;
    }

    public async Task CreateMegaverse(Goal goal)
    {
        try
        {
            var astralObjectsCount = goal.getAstralTotalObjectsCount();
            var astralObjectsCreatedCount = 1;

            Console.WriteLine("Creating Megaverse!!");
            foreach (var polyanet in goal.Polyanets)
            {
                ProgressBarHelper.UpdateProgressBar(astralObjectsCreatedCount, astralObjectsCount);
                astralObjectsCreatedCount++;
                await _polyanetProxy.CreatePolyanet(polyanet);
            }

            Console.WriteLine("\n-- Polyanets created --");

            Console.WriteLine("Megaverse completed!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }
}