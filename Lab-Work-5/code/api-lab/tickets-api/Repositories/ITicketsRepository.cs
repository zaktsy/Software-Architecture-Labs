using tickets_api.Models;

namespace tickets_api.Repositories;

public interface ITicketsRepository
{
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task AddAsync(Ticket newTicket);
    Task AddOrUpdateAsync(Ticket newTicket);
    Task DeleteAsync(Guid ticketId);
}