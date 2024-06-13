using QuotesFinder.DataAccess.Models;

namespace QuotesFinder.DataAccess;

public interface IQuotesGardenClient
{
    public Task<QuotesResponse> GetQuotesAsync(QuotesParams quotesParams);
}