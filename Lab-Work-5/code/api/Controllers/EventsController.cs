using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventsRepository _eventsRepository;

    public EventsController(IEventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

    [HttpGet(Name = "GetEvents")]
    public async Task<IActionResult> GetEvents()
    {
        try
        {
            var events = await _eventsRepository.GetAllAsync();
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
            await _eventsRepository.AddAsync(newEvent);

            return Ok();
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
           await _eventsRepository.AddOrUpdateAsync(changedEvent);

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
            await _eventsRepository.DeleteAsync(eventId);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}