namespace CrossmintChallenge.Core.Entities;

public class Goal
{
    public List<Polyanet> Polyanets { get; set; }
    public Goal()
    {
        Polyanets = new List<Polyanet>();
    }
}
