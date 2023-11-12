using CrossmintChallenge.Core.Entities;

namespace CrossmintChallenge.Core.Interfaces.Services;

public interface IMegaverseService
{
    public Task CreateMegaverse(Goal goal);
}
