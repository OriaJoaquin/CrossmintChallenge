namespace CrossmintChallenge.Core.Entities;

public class Goal
{
    public List<Polyanet> Polyanets { get; set; }
    public List<Cometh> Comeths { get; set; }
    public List<Soloon> Soloons { get; set; }
    public Goal()
    {
        Polyanets = new List<Polyanet>();
        Comeths = new List<Cometh>();
        Soloons = new List<Soloon>();
    }

    public int getAstralTotalObjectsCount()
    {
        return Polyanets.Count + Comeths.Count + Soloons.Count;
    }
}
