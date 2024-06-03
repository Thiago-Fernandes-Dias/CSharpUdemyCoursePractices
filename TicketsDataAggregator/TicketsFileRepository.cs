namespace TicketsDataAggregator;

internal class TicketsFileRepository(string filePath) : ITicketsRepository
{

    public void SaveMany(IEnumerable<Ticket> tickets)
    {
        using var file = File.Open(filePath, FileMode.OpenOrCreate);
        using var writer = new StreamWriter(file);
        foreach (var ticket in tickets)
            writer.WriteLine($"{ticket.Title,-30}| {ticket.Date} | {ticket.Time}");
    }
}
