using CrossmintChallenge.Core.Interfaces.Entities;
using System.Text.Json.Serialization;

namespace CrossmintChallenge.Core.Entities.API.Requests;

public class CreateComethRequest : IAstralObjectRequest
{
    [JsonPropertyName("row")]
    public int Row { get; set; }
    [JsonPropertyName("column")]
    public int Column { get; set; }
    [JsonPropertyName("candidateId")]
    public string CandidateId { get; set; }
    [JsonPropertyName("direction")]
    public string Direction { get; set; }
}
