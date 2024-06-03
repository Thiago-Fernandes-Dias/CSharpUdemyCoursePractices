using System.Globalization;
using System.Text;
using UglyToad.PdfPig;

namespace TicketsDataAggregator;

internal class PDFTicketsReader(string filePath) : ITicketsReader
{
    public IReadOnlyCollection<Ticket> ReadTickets()
    {
        ValidateFilePath(filePath);
        List<string> titles = [];
        List<string> dates = [];
        List<string> times = [];
        var culture = "";
        using var document = PdfDocument.Open(filePath);
        var page = document.GetPage(1);
        var words = page.GetWords().ToList();
        for (int i = 0; i < words.Count; i++)
        {
            if (words[i].Text == "Title:")
            {
                StringBuilder titleBuilder = new();
                for (int j = i + 1; words[j].Text != "Date:"; j++, i++)
                    titleBuilder.Append($"{words[j].Text} ");
                titles.Add(titleBuilder.ToString().TrimEnd());
            }
            else if (words[i].Text == "Date:")
            {
                StringBuilder dateBuilder = new();
                for (int j = i + 1; words[j].Text != "Time:"; j++, i++)
                    dateBuilder.Append($"{words[j].Text} ");
                dates.Add(dateBuilder.ToString().TrimEnd());
            }
            else if (words[i].Text == "Time:")
            {
                StringBuilder timeBuilder = new();
                List<string> endWords = ["Title:", "Visit"];
                for (int j = i + 1; !endWords.Contains(words[j].Text); j++, i++)
                    timeBuilder.Append($"{words[j].Text} ");
                times.Add(timeBuilder.ToString().TrimEnd());
            }
            else if (words[i].Text == "us:")
            {
                culture = ParseCulture(words[i + 1].Text.Split('.').Last());
            }
        }
        if (!SameSize([times, titles, dates]))
            throw new ArgumentException("Some tickets are invalid");
        List<Ticket> tickets = [];
        for (int i = 0; i < times.Count; i++)
        {
            var dateTime = DateTime.Parse($"{dates[i]} {times[i]}", new CultureInfo(culture));
            Ticket ticket = new(titles[i],
                                dateTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                                dateTime.ToString("HH:mm", CultureInfo.InvariantCulture));
            tickets.Add(ticket);
        }
        return tickets;
    }

    private static void ValidateFilePath(string filePath)
    {
        if (File.Exists(filePath) && filePath.Split(".").Last() == "pdf")
            return;
        throw new ArgumentException("The file is not a PDF.");
    }

    private static bool SameSize(IEnumerable<IEnumerable<string>> lists)
    {
        var size = lists.First().Count();
        return lists.All(list => list.Count() == size);
    }

    private static string ParseCulture(string culture) => culture switch
    {
        "jp" => "ja",
        "fr" => "fr-FR",
        _ => "en-US"
    };
}
