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
    private readonly IPolyanetProxy _polyanetProxy;
    private readonly IComethProxy _comethProxy;
    private readonly ISoloonProxy _soloonProxy;
    private readonly IAstralObjectProxy _astralObjectProxy;

    public MegaverseService(IPolyanetProxy polyanetProxy, IComethProxy comethProxy, ISoloonProxy soloonProxy, IAstralObjectProxy astralObjectProxy)
    {
        _polyanetProxy = polyanetProxy;
        _comethProxy = comethProxy;
        _soloonProxy = soloonProxy;
        _astralObjectProxy = astralObjectProxy;
    }

    public async Task CreateMegaverse(Goal goal)
    {
        try
        {
            var astralObjectsCount = goal.getAstralTotalObjectsCount();
            var astralObjectsCreatedCount = 1;

            var groupedByType = goal.AstralObjects.GroupBy(obj => obj.GetType());

            foreach (var group in groupedByType)
            {
                Console.WriteLine($"Creating Astral objects of type {group.Key.Name}");

                foreach (var astralObject in group)
                {
                    ProgressBarHelper.UpdateProgressBar(astralObjectsCreatedCount, astralObjectsCount);
                    astralObjectsCreatedCount++;
                    Thread.Sleep(500);
                    await _astralObjectProxy.CreateAstralObject(astralObject);
                }

                Console.WriteLine($"Astral objects of type {group.Key.Name} created !!!");
            }

            //Console.WriteLine("Creating Megaverse!!");
            //foreach (var polyanet in goal.Polyanets)
            //{
            //    ProgressBarHelper.UpdateProgressBar(astralObjectsCreatedCount, astralObjectsCount);
            //    astralObjectsCreatedCount++;
            //    Thread.Sleep(500);
            //    await _polyanetProxy.CreatePolyanet(polyanet);
            //}

            //Console.WriteLine("\n-- Polyanets created --");

            //foreach (var cometh in goal.Comeths)
            //{
            //    ProgressBarHelper.UpdateProgressBar(astralObjectsCreatedCount, astralObjectsCount);
            //    astralObjectsCreatedCount++;
            //    Thread.Sleep(500);
            //    await _comethProxy.CreateCometh(cometh);
            //}

            //Console.WriteLine("\n-- Comeths created --");

            //foreach (var soloon in goal.Soloons)
            //{
            //    ProgressBarHelper.UpdateProgressBar(astralObjectsCreatedCount, astralObjectsCount);
            //    astralObjectsCreatedCount++;
            //    Thread.Sleep(500);
            //    await _soloonProxy.CreateSoloon(soloon);
            //}

            //Console.WriteLine("\n-- Soloons created --");

            Console.WriteLine("Megaverse completed!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }
}