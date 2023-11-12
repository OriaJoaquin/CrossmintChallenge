using CrossmintChallenge.Core.Entities;

namespace CrossmintChallenge.Core.Interfaces.Services;

public interface IGoalService
{
    public Task<Goal> GetCurrentGoal();
}
