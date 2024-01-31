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
    public IActionResult GetEvents()
    {
        try
        {
            var events = _eventsRepository.GetAll();
            return Ok(events);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }



    [HttpPost(Name = "CreateEvent")]
    public IActionResult CreateEvent([FromQuery] string eventName)
    {
        try
        {
            var newEvent = new Event() { EventName = eventName };
            _eventsRepository.Add(newEvent);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut(Name = "ChangeEventNameOrAdd")]
    public IActionResult ChangeEventNameOrAdd([FromBody] Event changedEvent)
    {
        try
        {
            _eventsRepository.AddOrUpdate(changedEvent);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete(Name = "DeleteEvent")]
    public IActionResult DeleteEvent([FromQuery] Guid eventId)
    {
        try
        {
            _eventsRepository.Delete(eventId);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}