using System.Collections.Concurrent;
using api.Models;

namespace api.Repositories;

internal class EventsRepository : IEventsRepository
{
    private static readonly ConcurrentDictionary<Guid, Event> Events = new();
    public IEnumerable<Event> GetAll()
    {
        return Events.Values;
    }

    public void Add(Event newEvent)
    {
        Events.TryAdd(newEvent.EventId, newEvent);
    }

    public void AddOrUpdate(Event newEvent)
    {
        Events.AddOrUpdate(newEvent.EventId, newEvent, (_, _) => newEvent);
    }

    public void Delete(Guid eventId)
    {
        Events.TryRemove(eventId, out _);
    }
}