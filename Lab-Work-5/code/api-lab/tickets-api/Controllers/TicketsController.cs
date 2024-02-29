using Microsoft.AspNetCore.Mvc;
using tickets_api.Models;
using tickets_api.Repositories;

namespace tickets_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TicketsController(ITicketsRepository ticketsRepository) : ControllerBase
{
    [HttpGet(Name = "GetTickets")]
    public async Task<IActionResult> GetTickets()
    {
        try
        {
            var tickets = await ticketsRepository.GetAllAsync();
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
            await ticketsRepository.AddAsync(newTicket);

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
            await ticketsRepository.AddOrUpdateAsync(changedTicket);

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
            await ticketsRepository.DeleteAsync(ticketId);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}