using AutoMapper;
using CrossmintChallenge.Core.API.Requests;
using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Interfaces.Proxies;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace CrossmintChallenge.Infrastructure.Proxies;

public class PolyanetProxy : IPolyanetProxy
{
    private readonly string _apiBaseURL;
    private readonly string _postPolyanetEndpoint;
    private readonly string _candidateId;
    private readonly IMapper _mapper;

    public PolyanetProxy(IConfiguration configuration, IMapper mapper)
    {
        _apiBaseURL = configuration["APIBaseURL"];
        _postPolyanetEndpoint = configuration["Endpoints:Polyanets:PostPolyanet"];
        _candidateId = configuration["CandidateId"];
        _mapper = mapper;
    }

    public async Task CreatePolyanet(Polyanet polyanet)
    {
        try
        {
            string apiUrl = $"{_apiBaseURL}{_postPolyanetEndpoint}";

            var createPolyanetRequest = _mapper.Map<CreatePolyanetRequest>(polyanet);

            createPolyanetRequest.CandidateId = _candidateId;

            string jsonData = JsonSerializer.Serialize(createPolyanetRequest);

            using (HttpClient client = new HttpClient())
            using (HttpContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    //Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    throw new Exception("Something went wrong while creating Polyanets");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
