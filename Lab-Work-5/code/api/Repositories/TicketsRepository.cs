using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

internal class TicketsRepository : ITicketsRepository
{
    private readonly ApiDbContext _context;

    public TicketsRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task AddAsync(Ticket newTicket)
    {
        await _context.AddAsync(newTicket);
        await _context.SaveChangesAsync();
    }

    public async Task AddOrUpdateAsync(Ticket newTicket)
    {
        _context.Update(newTicket);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid ticketId)
    {
        var ticket = await _context.FindAsync<Ticket>(ticketId);

        if (ticket == null)
            return;

        _context.Remove((object)ticket);

        await _context.SaveChangesAsync();
    }
}