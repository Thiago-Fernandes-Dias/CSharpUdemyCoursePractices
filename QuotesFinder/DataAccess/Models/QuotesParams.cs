namespace QuotesFinder.DataAccess.Models;

public record QuotesParams (
    string? Author,
    string? Genre,
    string? Query,
    int? Page,
    int? Limit
);