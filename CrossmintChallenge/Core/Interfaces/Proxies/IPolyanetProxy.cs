using CrossmintChallenge.Core.Entities;

namespace CrossmintChallenge.Core.Interfaces.Proxies;

public interface IPolyanetProxy
{
    public Task CreatePolyanet(Polyanet polyanet);
}
