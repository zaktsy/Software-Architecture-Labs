using Microsoft.EntityFrameworkCore;
using tickets_api.Models;

namespace tickets_api.Repositories;

internal class TicketsRepository(TicketsDbContext context) : ITicketsRepository
{
    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await context.Tickets.ToListAsync();
    }

    public async Task AddAsync(Ticket newTicket)
    {
        await context.AddAsync(newTicket);
        await context.SaveChangesAsync();
    }

    public async Task AddOrUpdateAsync(Ticket newTicket)
    {
        context.Update(newTicket);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid ticketId)
    {
        var ticket = await context.FindAsync<Ticket>(ticketId);

        if (ticket == null)
            return;

        context.Remove((object)ticket);

        await context.SaveChangesAsync();
    }
}