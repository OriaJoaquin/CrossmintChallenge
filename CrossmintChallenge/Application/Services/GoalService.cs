using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Interfaces.Proxies;
using CrossmintChallenge.Core.Interfaces.Services;

namespace CrossmintChallenge.Application.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalProxy _goalProxy;

        public GoalService(IGoalProxy goalProxy)
        {
            _goalProxy = goalProxy;
        }

        public async Task<Goal> GetCurrentGoal()
        {
            return await _goalProxy.GetCurrentGoal();
        }
    }
}
