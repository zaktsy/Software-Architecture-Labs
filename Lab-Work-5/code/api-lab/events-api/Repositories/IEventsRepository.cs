using events_api.Models;

namespace events_api.Repositories;

public interface IEventsRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task AddAsync(Event newEvent);
    Task AddOrUpdateAsync(Event newEvent);
    Task DeleteAsync(Guid eventId);
}