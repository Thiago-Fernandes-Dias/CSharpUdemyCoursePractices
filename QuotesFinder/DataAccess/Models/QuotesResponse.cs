using System.Text.Json.Serialization;

namespace QuotesFinder.DataAccess.Models;

public record QuotesResponse(
    [property: JsonPropertyName("statusCode")] int? StatusCode,
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("pagination")] Pagination Pagination,
    [property: JsonPropertyName("totalQuotes")] int? TotalQuotes,
    [property: JsonPropertyName("data")] IReadOnlyList<Datum> Data
);

public record Datum(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("quoteText")] string QuoteText,
    [property: JsonPropertyName("quoteAuthor")] string QuoteAuthor,
    [property: JsonPropertyName("quoteGenre")] string QuoteGenre,
    [property: JsonPropertyName("__v")] int? V
);

public record Pagination(
    [property: JsonPropertyName("currentPage")] int? CurrentPage,
    [property: JsonPropertyName("nextPage")] int? NextPage,
    [property: JsonPropertyName("totalPages")] int? TotalPages
);
