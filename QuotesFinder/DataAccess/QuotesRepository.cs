using QuotesFinder.DataAccess.Models;

namespace QuotesFinder.DataAccess;

public class QuotesRepository(IQuotesGardenClient quotesGardenClient) : IQuotesRepository
{
    public async Task<IEnumerable<Datum>> GetAllQuotesThatContains(string word, (int numberOfPages, int quotesPerPage) searchLenghtParams)
    {
        var searchTasks = new List<Task<QuotesResponse>>();
        for (int i = 1; i <= searchLenghtParams.numberOfPages; i++)
        {
            var task = quotesGardenClient.GetQuotesAsync(new QuotesParams(null, null, word, i, searchLenghtParams.quotesPerPage));
            searchTasks.Add(task);
        }
        var quotesResponses = await Task.WhenAll(searchTasks);
        var result = quotesResponses.SelectMany(qr => qr.Data);
        return result;
    }
}
