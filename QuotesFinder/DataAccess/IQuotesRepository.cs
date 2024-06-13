using QuotesFinder.DataAccess.Models;

namespace QuotesFinder.DataAccess;

public interface IQuotesRepository
{
    public Task<IEnumerable<Datum>> GetAllQuotesThatContains(string word, (int numberOfPages, int quotesPerPage) searchLenghtParams);
}
