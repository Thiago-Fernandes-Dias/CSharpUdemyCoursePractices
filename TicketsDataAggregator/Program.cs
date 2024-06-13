using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using UglyToad.PdfPig;

namespace TicketsDataAggregator;

internal class Program
{
    static void Main(string[] args)
    {
        var directoryPath = @"C:\Users\thiag\Downloads\Tickets";
        var filePaths = Directory.GetFiles($@"{directoryPath}", "*.pdf");
        List<Ticket> tickets = []; 
        foreach (var filePath in filePaths)
        {
            ITicketsReader ticketsReader = new PDFTicketsReader(filePath);
            tickets.AddRange(ticketsReader.ReadTickets());
        }
        ITicketsRepository repo = new TicketsFileRepository(Path.Combine(directoryPath, "aggregatedTickets.txt"));
        repo.SaveMany(tickets);
        return;
    }
}
