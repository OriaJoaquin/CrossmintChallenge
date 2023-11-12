﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrossmintChallenge.Core.API.Requests
{
    public class CreatePolyanetRequest
    {
        [JsonPropertyName("row")]
        public int Row { get; set; }
        [JsonPropertyName("column")]
        public int Column { get; set; }
        [JsonPropertyName("candidateId")]
        public string CandidateId { get; set; }
    }
}
