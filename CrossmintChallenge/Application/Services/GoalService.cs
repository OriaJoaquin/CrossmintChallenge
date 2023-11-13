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
            var goal = await _goalProxy.GetCurrentGoal();

            Console.WriteLine("This is our current goal map. We need to create:");
            Console.WriteLine($"\t*{goal.Polyanets.Count} Polyanets.");
            Console.WriteLine($"\t*{goal.Comeths.Count} Comeths.");
            Console.WriteLine($"\t*{goal.Soloons.Count} Soloons.");
            
            return goal;
        }
    }
}
