using api.Models;

namespace api.Repositories;

public interface IEventsRepository
{
    IEnumerable<Event> GetAll();
    void Add(Event newEvent);
    void AddOrUpdate(Event newEvent);
    void Delete(Guid eventId);
}