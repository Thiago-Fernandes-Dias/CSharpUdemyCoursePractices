using QuotesFinder.DataAccess;
using Utils;

namespace QuotesFinder;

internal class Program
{
    static void Main(string[] args)
    {
        var quotesGardenClient = new QuotesGardenClient(() => new HttpClient());
        var quotesRepository = new QuotesRepository(quotesGardenClient);
        var consoleInterface = new ConsoleInterface();
        var consoleUserInterface = new ConsoleUserInterface(consoleInterface);
        var quotesFinderManager = new QuotesFinderManager(quotesRepository, consoleUserInterface);
        quotesFinderManager.Run();
    }
}
