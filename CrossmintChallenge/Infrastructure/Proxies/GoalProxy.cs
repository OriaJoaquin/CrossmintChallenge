using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Entities.API.Responses;
using CrossmintChallenge.Core.Interfaces.Proxies;
using Microsoft.Extensions.Configuration;
using System.Text.Json;


namespace CrossmintChallenge.Infrastructure.Proxies;

public class GoalProxy : IGoalProxy
{
    public readonly string _apiBaseURL;
    public readonly string _getCurrentGoalEndpoint;
    public readonly string _candidateId;
    public GoalProxy(IConfiguration configuration)
    {
        _apiBaseURL = configuration["APIBaseURL"];
        _getCurrentGoalEndpoint = configuration["Endpoints:Goals:GetCurrentGoal"];
        _candidateId = configuration["CandidateId"];
    }

    public async Task<Goal> GetCurrentGoal()
    {
        string apiUrl = $"{_apiBaseURL}{_getCurrentGoalEndpoint}";

        apiUrl = string.Format(apiUrl, _candidateId);

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    GoalResponse goalResponse = JsonSerializer.Deserialize<GoalResponse>(apiResponse);

                    return MapGoalResponseToGoal(goalResponse);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}");
            }
        }

        return null;
    }

    private Goal MapGoalResponseToGoal(GoalResponse goalResponse)
    {
        var goal = new Goal();

        foreach (var row in goalResponse.Goal.Select((columns, rowIndex) => (columns, rowIndex)))
        {
            foreach (var column in row.columns.Select((astralObject, columnIndex) => (astralObject, columnIndex)))
            {
                if (column.astralObject == "POLYANET")
                {
                    goal.AstralObjects.Add(new Polyanet() { Row = row.rowIndex, Column = column.columnIndex });
                }

                if (column.astralObject.Contains("COMETH"))
                {
                    var aux = column.astralObject.Split("_");
                    goal.AstralObjects.Add(new Cometh() { Row = row.rowIndex, Column = column.columnIndex, Direction = aux[0].ToLower() });
                }

                if (column.astralObject.Contains("SOLOON"))
                {
                    var aux = column.astralObject.Split("_");
                    goal.AstralObjects.Add(new Soloon() { Row = row.rowIndex, Column = column.columnIndex, Color = aux[0].ToLower() });
                }

            }
        }

        return goal;
    }
}
