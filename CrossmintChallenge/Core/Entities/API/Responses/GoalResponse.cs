using System.Text.Json.Serialization;

namespace CrossmintChallenge.Core.Entities.API.Responses;

public class GoalResponse
{
    [JsonPropertyName("goal")]
    public List<List<string>> Goal { get; set; }
}
