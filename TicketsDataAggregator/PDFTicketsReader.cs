using System.Globalization;
using System.Transactions;
using UglyToad.PdfPig;

namespace TicketsDataAggregator;

internal class PDFTicketsReader(string filePath) : ITicketsReader
{
    private static readonly Dictionary<string, CultureInfo> _cultureStrToCultureInfo = new()
    {
        ["jp"] = new CultureInfo("ja"),
        ["fr"] = new CultureInfo("fr-FR"),
        ["com"] = new CultureInfo("en-US")
    };

    public IReadOnlyCollection<Ticket> ReadTickets()
    {
        ValidateFilePath(filePath);
        using var document = PdfDocument.Open(filePath);
        var page = document.GetPage(1);
        var pageText = page.Text;
        var pageTextSplitted = pageText.Split(new string[] { "Title:", "Date:", "Time:", "Visit us:" }, StringSplitOptions.None);
        var cultureInfo = _cultureStrToCultureInfo[ExtractCulture(pageTextSplitted.Last())];
        List<Ticket> tickets = [];
        for (int i = 1; i < pageTextSplitted.Length - 3; i += 3)
        {
            var date = DateOnly.Parse(pageTextSplitted[i + 1], cultureInfo);
            var time = TimeOnly.Parse(pageTextSplitted[i + 2], cultureInfo);
            Ticket ticket = new(pageTextSplitted[i],
                                date.ToString(CultureInfo.InvariantCulture),
                                time.ToString(CultureInfo.InvariantCulture));
            tickets.Add(ticket);
        }
        return tickets;
    }

    private string ExtractCulture(string websiteUrl)
    {
        return websiteUrl.Split(".").Last();
    }

    private static void ValidateFilePath(string filePath)
    {
        if (File.Exists(filePath) && filePath.Split(".").Last() == "pdf")
            return;
        throw new ArgumentException("The file is not a PDF.");
    }
}
