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
    public class ComethProxy : IComethProxy
    {
        private readonly string _apiBaseURL;
        private readonly string _postComethEndpoint;
        private readonly string _candidateId;
        private readonly IMapper _mapper;

        public ComethProxy(IConfiguration configuration, IMapper mapper)
        {
            _apiBaseURL = configuration["APIBaseURL"];
            _postComethEndpoint = configuration["Endpoints:Comeths:PostCometh"];
            _candidateId = configuration["CandidateId"];
            _mapper = mapper;
        }

        public async Task CreateCometh(Cometh cometh)
        {
            try
            {
                string apiUrl = $"{_apiBaseURL}{_postComethEndpoint}";

                var createComethRequest = _mapper.Map<CreateComethRequest>(cometh);

                createComethRequest.CandidateId = _candidateId;

                string jsonData = JsonSerializer.Serialize(createComethRequest);

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
                        throw new Exception("Something went wrong while creating Comeths");
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
