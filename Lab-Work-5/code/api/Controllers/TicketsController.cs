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
    public async Task<IActionResult> GetTickets()
    {
        try
        {
            var tickets = await _ticketsRepository.GetAllAsync();
            return Ok(tickets);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


    [HttpPost(Name = "CreateTicket")]
    public async Task<IActionResult> CreateTicket([FromQuery] string ownerName, [FromQuery] Guid eventId)
    {
        try
        {
            var newTicket = new Ticket() { Owner = ownerName, EventId = eventId};
            await _ticketsRepository.AddAsync(newTicket);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut(Name = "ChangeTicketNameOrAdd")]
    public async Task<IActionResult> ChangeTicketNameOrAdd([FromBody] Ticket changedTicket)
    {
        try
        {
            await _ticketsRepository.AddOrUpdateAsync(changedTicket);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete(Name = "DeleteTicket")]
    public async Task<IActionResult> DeleteTicket([FromQuery] Guid ticketId)
    {
        try
        {
            await _ticketsRepository.DeleteAsync(ticketId);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}