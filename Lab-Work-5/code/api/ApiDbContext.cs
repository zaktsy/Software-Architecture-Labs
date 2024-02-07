using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Event> Events { get; set; }

    public DbSet<Ticket> Tickets { get; set; }
}