using events_api.Models;
using Microsoft.EntityFrameworkCore;

namespace events_api.Repositories;

internal class EventsRepository(ApiDbContext context) : IEventsRepository
{
    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await context.Events.ToListAsync();
    }

    public async Task AddAsync(Event newEvent)
    {
        await context.AddAsync(newEvent);
        await context.SaveChangesAsync();
    }

    public async Task AddOrUpdateAsync(Event newEvent)
    {
        context.Update(newEvent);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid eventId)
    {
        var @event = await context.FindAsync<Event>(eventId);

        if (@event == null)
            return;

        context.Remove((object)@event);

        await context.SaveChangesAsync();
    }
}