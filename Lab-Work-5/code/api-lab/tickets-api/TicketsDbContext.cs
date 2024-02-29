using Microsoft.EntityFrameworkCore;
using tickets_api.Models;

namespace tickets_api;

public class TicketsDbContext : DbContext
{
    public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Ticket> Tickets { get; set; }
}