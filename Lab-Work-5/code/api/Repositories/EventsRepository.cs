using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

internal class EventsRepository : IEventsRepository
{
    private readonly ApiDbContext _context;

    public EventsRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task AddAsync(Event newEvent)
    {
        await _context.AddAsync(newEvent);
        await _context.SaveChangesAsync();
    }

    public async Task AddOrUpdateAsync(Event newEvent)
    {
        _context.Update(newEvent);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid eventId)
    {
        var @event = await _context.FindAsync<Event>(eventId);

        if (@event == null)
            return;

        _context.Remove((object)@event);

        await _context.SaveChangesAsync();
    }
}