using System.Collections;
using StarWarsPlanetsStats.DataTransferObjects;

namespace StarWarsPlanetsStats.Models;

public readonly struct Planet(string name, int rotationPeriod, int orbitalPeriod,
                             int diameter, string climate, string gravity,
                             string terrain, int? surfaceWater, int? population)
{
    public readonly string Name = name;
    public readonly int RotationPeriod = rotationPeriod;
    public readonly int OrbitalPeriod = orbitalPeriod;
    public readonly int Diameter = diameter;
    public readonly string Climate = climate;
    public readonly string Gravity = gravity;
    public readonly string Terrain = terrain;
    public readonly int? SurfaceWater = surfaceWater;
    public readonly int? Population = population;

    public static explicit operator Planet(PlanetDTO dto)
    {
        var name = dto.Name;
        var rotationPeriod = int.Parse(dto.RotationPeriod);
        var orbitalPeriod = int.Parse(dto.OrbitalPeriod);
        var diameter = int.Parse(dto.RotationPeriod);
        var climate = dto.Climate;
        var gravity = dto.Gravity;
        var terrain = dto.Terrain;
        var array = new ArrayList();
        _ = int.TryParse(dto.SurfaceWater, out int surfaceWater);
        _ = int.TryParse(dto.Population, out int population);
        return new Planet(name, rotationPeriod, orbitalPeriod,
                          diameter, climate, gravity,
                          terrain, surfaceWater, population);
    }
}
