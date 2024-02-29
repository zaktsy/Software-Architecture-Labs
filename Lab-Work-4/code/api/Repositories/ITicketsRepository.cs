using api.Models;

namespace api.Repositories;

public interface ITicketsRepository
{
    public IEnumerable<Ticket>? GetAll();

    public void Add(Ticket newTicket);

    public void AddOrUpdate(Ticket newTicket);

    public void Delete(Guid ticketId);
}