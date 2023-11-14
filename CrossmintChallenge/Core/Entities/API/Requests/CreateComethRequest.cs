using CrossmintChallenge.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrossmintChallenge.Core.Entities.API.Requests
{
    public class CreateComethRequest : IAstralObjectRequest
    {
        public CreateComethRequest()
        {

        }

        public CreateComethRequest(string direction)
        {
            Direction = direction;
        }

        [JsonPropertyName("row")]
        public int Row { get; set; }
        [JsonPropertyName("column")]
        public int Column { get; set; }
        [JsonPropertyName("candidateId")]
        public string CandidateId { get; set; }
        [JsonPropertyName("direction")]
        public string Direction { get; set; }
    }
}
