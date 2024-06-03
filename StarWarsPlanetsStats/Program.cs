using StarWarsPlanetsStats.ApiDataAccess;

namespace StarWarsPlanetsStats
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var repo = new StarWarsPlanetsRepositoryImpl(new MockStarWarsApiDataReader());
            var planets = await repo.GetPlanets();
            Console.WriteLine(planets);
            Console.WriteLine("Hello, World!");
        }
    }
}
