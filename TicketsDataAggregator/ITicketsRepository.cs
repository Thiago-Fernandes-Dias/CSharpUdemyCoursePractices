namespace TicketsDataAggregator;

internal interface ITicketsRepository
{
    public void SaveMany(IEnumerable<Ticket> tickets);
}
