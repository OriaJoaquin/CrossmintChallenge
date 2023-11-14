using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Entities.API.Responses;
using CrossmintChallenge.Core.Enums;
using CrossmintChallenge.Core.Interfaces.Entities;
using CrossmintChallenge.Core.Interfaces.Proxies;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
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
                    throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                Environment.Exit(0);
                throw new Exception(e.Message);
            }
        }
    }

    private Goal MapGoalResponseToGoal(GoalResponse goalResponse)
    {
        var goal = new Goal();

        foreach (var row in goalResponse.Goal.Select((columns, index) => (columns, index)))
        {
            foreach (var column in row.columns.Select((astralObjectName, index) => (astralObjectName, index)))
            {
                var createdAstralObject = CreateAstralObject(column.astralObjectName, row.index, column.index);
                
                if (createdAstralObject != null) {
                    goal.AstralObjects.Add(createdAstralObject); 
                }

            }
        }

        return goal;
    }

    private IAstralObject CreateAstralObject(string astralObjectName, int rowIndex, int columnIndex)
    {
        if (astralObjectName == AstralObjectEnum.Polyanet)
        {
            return new Polyanet() { Row = rowIndex, Column = columnIndex };
        }

        if (astralObjectName.Contains(AstralObjectEnum.Cometh))
        {
            var aux = astralObjectName.Split("_");
            return new Cometh() { Row = rowIndex, Column = columnIndex, Direction = aux[0].ToLower() };
        }

        if (astralObjectName.Contains(AstralObjectEnum.Soloon))
        {
            var aux = astralObjectName.Split("_");
            return new Soloon() { Row = rowIndex, Column = columnIndex, Color = aux[0].ToLower() };
        }

        return null;
    }
}
