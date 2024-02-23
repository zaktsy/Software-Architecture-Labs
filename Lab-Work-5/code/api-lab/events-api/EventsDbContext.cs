using events_api.Models;
using Microsoft.EntityFrameworkCore;

namespace events_api;

public class EventsDbContext : DbContext
{
    public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Event> Events { get; set; }
}