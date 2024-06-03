namespace StarWarsPlanetsStats.Repositories;

using StarWarsPlanetsStats.Models;

public interface IStarWarsPlanetsRepository
{
    public Task<List<Planet>> GetPlanets();
}