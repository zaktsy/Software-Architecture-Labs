using api.Models;

namespace api.Repositories;

public interface ITicketsRepository
{
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task AddAsync(Ticket newTicket);
    Task AddOrUpdateAsync(Ticket newTicket);
    Task DeleteAsync(Guid ticketId);
}