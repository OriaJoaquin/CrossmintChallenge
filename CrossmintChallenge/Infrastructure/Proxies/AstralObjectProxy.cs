using CrossmintChallenge.Core.Entities.API.Requests;
using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Interfaces.Entities;
using CrossmintChallenge.Core.Interfaces.Proxies;
using System.Text.Json;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace CrossmintChallenge.Infrastructure.Proxies;

public class AstralObjectProxy : IAstralObjectProxy
{
    private readonly string _apiBaseURL;
    private readonly Dictionary<Type, string> _postEndpoints;
    private readonly string _candidateId;
    private readonly IMapper _mapper;

    public AstralObjectProxy(IConfiguration configuration, IMapper mapper)
    {
        _apiBaseURL = configuration["APIBaseURL"];
        _postEndpoints = new Dictionary<Type, string>
        {
            { typeof(Soloon) , configuration["Endpoints:Soloons:PostSoloon"] },
            { typeof(Polyanet), configuration["Endpoints:Polyanets:PostPolyanet"] },
            { typeof(Cometh), configuration["Endpoints:Comeths:PostCometh"] }
        };
        _candidateId = configuration["CandidateId"];
        _mapper = mapper;
    }

    public async Task CreateAstralObject(IAstralObject astralObject)
    {
        try
        {
            string apiUrl = $"{_apiBaseURL}{_postEndpoints[astralObject.GetType()]}";

            var createAstralObjectRequest = _mapper.Map<IAstralObjectRequest>(astralObject);

            createAstralObjectRequest.CandidateId = _candidateId;

            string jsonData = JsonSerializer.Serialize(createAstralObjectRequest, createAstralObjectRequest.GetType());

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
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    throw new Exception($"Something went wrong while creating {astralObject.GetType()}");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
