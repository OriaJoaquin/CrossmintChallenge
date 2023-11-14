using CrossmintChallenge.Core.Interfaces.Entities;

namespace CrossmintChallenge.Core.Entities;

public class Goal
{
    public List<IAstralObject> AstralObjects { get; set; }
    public Goal()
    {
        AstralObjects = new List<IAstralObject>();
    }
}
