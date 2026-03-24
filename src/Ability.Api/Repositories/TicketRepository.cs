using Ability.Api.Data;
using Ability.Api.Models;
using Ability.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ability.Api.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStatusAsync(Guid id, TicketStatus newStatus)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket != null)
        {
            ticket.Status = newStatus;
            await _context.SaveChangesAsync();
        }
    }
}