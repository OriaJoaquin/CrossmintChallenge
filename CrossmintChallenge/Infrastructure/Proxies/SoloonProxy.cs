using AutoMapper;
using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Entities.API.Requests;
using CrossmintChallenge.Core.Interfaces.Proxies;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrossmintChallenge.Infrastructure.Proxies
{
    public class SoloonProxy : ISoloonProxy
    {
        private readonly string _apiBaseURL;
        private readonly string _postSoloonEndpoint;
        private readonly string _candidateId;
        private readonly IMapper _mapper;

        public SoloonProxy(IConfiguration configuration, IMapper mapper)
        {
            _apiBaseURL = configuration["APIBaseURL"];
            _postSoloonEndpoint = configuration["Endpoints:Soloons:PostSoloon"];
            _candidateId = configuration["CandidateId"];
            _mapper = mapper;
        }

        public async Task CreateSoloon(Soloon soloon)
        {
            try
            {
                string apiUrl = $"{_apiBaseURL}{_postSoloonEndpoint}";

                var createSoloonRequest = _mapper.Map<CreateSoloonRequest>(soloon);

                createSoloonRequest.CandidateId = _candidateId;

                string jsonData = JsonSerializer.Serialize(createSoloonRequest);

                using (HttpClient client = new HttpClient())
                using (HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        throw new Exception("Something went wrong while creating Soloons");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
