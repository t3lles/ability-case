using Ability.Api.Models;
using Ability.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ability.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketRepository _repository;

    public TicketsController(ITicketRepository repository)
    {
        _repository = repository;
    }

    // GET: api/tickets
    // List all tickets
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _repository.GetAllAsync();
        return Ok(tickets);
    }

    // POST: api/tickets
    // Create a new ticket
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Ticket ticket)
    {
        if (ticket == null || string.IsNullOrWhiteSpace(ticket.Title))
        {
            return BadRequest("Title is required.");
        }

        // Set default values for a new ticket
        ticket.Id = Guid.NewGuid();
        ticket.CreatedAt = DateTime.UtcNow;
        ticket.Status = TicketStatus.Aberto;

        await _repository.AddAsync(ticket);

        // Return 201 Created
        return CreatedAtAction(nameof(GetAll), new { id = ticket.Id }, ticket);
    }

    // PUT: api/tickets/{id}
    // Update a ticket status to 'Concluido'
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStatus(Guid id)
    {
        await _repository.UpdateStatusAsync(id, TicketStatus.Concluido);

        return NoContent();
    }
}