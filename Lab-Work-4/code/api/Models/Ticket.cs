namespace api.Models;

public class Ticket
{
    public Guid TicketId { get; init; } = Guid.NewGuid();
    public Guid EventId { get; init; }
    public string Owner { get; set; } = string.Empty;
}