namespace TicketsDataAggregator;

internal interface ITicketsReader
{
    public IReadOnlyCollection<Ticket> ReadTickets();
}
