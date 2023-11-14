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

            Console.WriteLine($"This is our current map goal:");

            var groupedByType = goal.AstralObjects.GroupBy(obj => obj.GetType());

            foreach (var group in groupedByType)
            {
                Console.WriteLine($"\t *Astral objects of type {group.Key.Name}: {group.Count()}");
            }

            return goal;
        }
    }
}
