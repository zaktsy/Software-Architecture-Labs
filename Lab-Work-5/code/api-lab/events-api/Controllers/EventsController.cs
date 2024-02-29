using events_api.Models;
using events_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace events_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EventsController(IEventsRepository eventsRepository) : ControllerBase
{
    [HttpGet(Name = "GetEvents")]
    public async Task<IActionResult> GetEvents()
    {
        try
        {
            var events = await eventsRepository.GetAllAsync();
            return Ok(events);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost(Name = "CreateEvent")]
    public async Task<IActionResult> CreateEvent([FromQuery] string eventName)
    {
        try
        {
            var newEvent = new Event() { EventName = eventName };
            await eventsRepository.AddAsync(newEvent);

            return Ok("good!");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut(Name = "ChangeEventNameOrAdd")]
    public async Task<IActionResult> ChangeEventNameOrAdd([FromBody] Event changedEvent)
    {
        try
        {
           await eventsRepository.AddOrUpdateAsync(changedEvent);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete(Name = "DeleteEvent")]
    public async Task<IActionResult> DeleteEvent([FromQuery] Guid eventId)
    {
        try
        {
            await eventsRepository.DeleteAsync(eventId);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}