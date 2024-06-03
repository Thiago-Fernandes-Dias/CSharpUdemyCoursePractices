using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace StarWarsPlanetsStats.DataTransferObjects;

public record PlanetsResponse(
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("next")] string Next,
    [property: JsonPropertyName("previous")] string? Previous,
    [property: JsonPropertyName("results")] IReadOnlyList<PlanetDTO> Results
);

