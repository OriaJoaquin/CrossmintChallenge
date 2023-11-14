using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Interfaces.Proxies;
using CrossmintChallenge.Core.Interfaces.Services;
using System.Buffers.Text;
using System.Threading.Tasks;
using System;
using CrossmintChallenge.Infrastructure.Proxies;
using CrossmintChallenge.Application.Helpers;

namespace CrossmintChallenge.Application.Services;

public class MegaverseService : IMegaverseService
{
    private readonly IAstralObjectProxy _astralObjectProxy;

    public MegaverseService(IAstralObjectProxy astralObjectProxy)
    {
        _astralObjectProxy = astralObjectProxy;
    }

    public async Task CreateMegaverse(Goal goal)
    {
        try
        {
            var astralObjectsCount = goal.AstralObjects.Count();
            var astralObjectsCreatedCount = 1;

            var groupedByType = goal.AstralObjects.GroupBy(obj => obj.GetType());

            foreach (var group in groupedByType)
            {
                Console.WriteLine($"\nCreating Astral objects of type {group.Key.Name}");

                foreach (var astralObject in group)
                {
                    ProgressBarHelper.UpdateProgressBar(astralObjectsCreatedCount, astralObjectsCount);
                    astralObjectsCreatedCount++;
                    Thread.Sleep(600);
                    await _astralObjectProxy.CreateAstralObject(astralObject);
                }

                Console.WriteLine($"\nAstral objects of type {group.Key.Name} created !!!");
            }

            Console.WriteLine("Megaverse completed!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }
}