using CrossmintChallenge.Core.Entities;

namespace CrossmintChallenge.Core.Interfaces.Proxies
{
    public interface IGoalProxy
    {
        public Task<Goal> GetCurrentGoal();
    }
}
