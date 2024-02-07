namespace api.Models;

public class Event
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public string EventName { get; set; } = string.Empty;
}