using CrossmintChallenge.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrossmintChallenge.Core.Entities.API.Requests
{
    public class CreateSoloonRequest : IAstralObjectRequest
    {
        public CreateSoloonRequest()
        {

        }
        public CreateSoloonRequest(string color)
        {
            Color = color;
        }

        [JsonPropertyName("row")]
        public int Row { get; set; }
        [JsonPropertyName("column")]
        public int Column { get; set; }
        [JsonPropertyName("candidateId")]
        public string CandidateId { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
