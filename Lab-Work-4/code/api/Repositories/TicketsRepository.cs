using System.Collections.Concurrent;
using api.Models;

namespace api.Repositories;

internal class TicketsRepository : ITicketsRepository
{
    private static readonly ConcurrentDictionary<Guid, Ticket> Tickets = new();
    public IEnumerable<Ticket> GetAll()
    {
        return Tickets.Values;
    }

    public void Add(Ticket newEvent)
    {
        Tickets.TryAdd(newEvent.TicketId, newEvent);
    }

    public void AddOrUpdate(Ticket newTicket)
    {
        Tickets.AddOrUpdate(newTicket.TicketId, newTicket, (_, ticket) => ticket);
    }

    public void Delete(Guid eventId)
    {
        Tickets.TryRemove(eventId, out _);
    }
}