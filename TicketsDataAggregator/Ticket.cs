using System;
namespace TicketsDataAggregator;

internal readonly struct Ticket(string title, string date, string time)
{
    public readonly string Title = title;
    public readonly string Date = date;
    public readonly string Time = time;

    public override string ToString()
    {
        return $"Title: {Title}; Date: {Date}, Time: {Time}";
    }
}
