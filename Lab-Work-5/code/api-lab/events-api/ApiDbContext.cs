using events_api.Models;
using Microsoft.EntityFrameworkCore;

namespace events_api;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Event> Events { get; set; }
}