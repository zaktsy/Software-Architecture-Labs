using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketsRepository _ticketsRepository;

    public TicketsController(ITicketsRepository ticketsRepository)
    {
        _ticketsRepository = ticketsRepository;
    }


    [HttpGet(Name = "GetTickets")]
    public IActionResult GetTickets()
    {
        try
        {
            var tickets = _ticketsRepository.GetAll();
            return Ok(tickets);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


    [HttpPost(Name = "CreateTicket")]
    public IActionResult CreateTicket([FromQuery] string ownerName, [FromQuery] Guid eventId)
    {
        try
        {
            var newTicket = new Ticket() { Owner = ownerName, EventId = eventId};
            _ticketsRepository.Add(newTicket);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut(Name = "ChangeTicketNameOrAdd")]
    public IActionResult ChangeTicketNameOrAdd([FromBody] Ticket changedTicket)
    {
        try
        {
            _ticketsRepository.AddOrUpdate(changedTicket);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete(Name = "DeleteTicket")]
    public IActionResult DeleteTicket([FromQuery] Guid ticketId)
    {
        try
        {
            _ticketsRepository.Delete(ticketId);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}