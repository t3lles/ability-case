using Ability.Api.Models;

namespace Ability.Api.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task AddAsync(Ticket ticket);
        Task UpdateStatusAsync(Guid id, TicketStatus newStatus);
    }


}
