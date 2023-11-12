﻿using CrossmintChallenge.Core.API.Responses;
using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Interfaces.Proxies;
using Microsoft.Extensions.Configuration;
using System.Text.Json;


namespace CrossmintChallenge.Infrstructure;

public class GoalProxy : IGoalProxy
{
    public string _apiBaseURL { get; set; }
    public string _getCurrentGoalEndpoint { get; set; }
    public string _candidateId { get; set; }



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
                    goal.Polyanets.Add(new Polyanet() { Row = row.rowIndex, Column = column.columnIndex });
                }
            }
        }

        return goal;
    }
}
