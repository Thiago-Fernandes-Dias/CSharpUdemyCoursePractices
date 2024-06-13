using QuotesFinder.DataAccess;
using Utils;

namespace QuotesFinder;

public class QuotesFinderManager(IQuotesRepository quotesRepository, IUserInterface userInterface)
{
    public void Run()
    {
        var pages = userInterface.ReadInteger(Questions.NumberOfPages, p => p > 0);
        var quotesPerPage = userInterface.ReadInteger(Questions.NumberOfQuotes, q => q > 0);
        var word = userInterface.ReadString(Questions.Word, w => w.IsSingleWord());
        var quotes = quotesRepository.GetAllQuotesThatContains(word, (pages, quotesPerPage)).Result;
        if (quotes.Count() > 0)
            foreach (var quote in quotes)
                Console.WriteLine(quote.QuoteText);
        else
            Console.WriteLine("No quotes to show.");
    }
}