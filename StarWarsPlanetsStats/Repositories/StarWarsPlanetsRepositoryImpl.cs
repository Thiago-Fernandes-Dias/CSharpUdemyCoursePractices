using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.DataTransferObjects;
using StarWarsPlanetsStats.Models;
using StarWarsPlanetsStats.Repositories;

namespace StarWarsPlanetsStats;

public class StarWarsPlanetsRepositoryImpl(IApiDataReader apiDataReader) : IStarWarsPlanetsRepository
{
    private readonly IApiDataReader _apiDataReader = apiDataReader; 

    private const string BaseUrl = "https://swapi.dev/";

    public async Task<List<Planet>> GetPlanets()
    {
        var jsonString = await _apiDataReader.Read(BaseUrl, "api/planets");
        Console.WriteLine(jsonString);
        var planetsResponse = JsonSerializer.Deserialize<PlanetsResponse>(jsonString);
        if (planetsResponse is null)
            return [];
        return planetsResponse.Results.Select(planetDTO => (Planet) planetDTO).ToList();
    }
}