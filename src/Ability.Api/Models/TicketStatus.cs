namespace Ability.Api.Models
{
    public enum TicketStatus
    {
        Aberto = 0,
        EmAndamento = 1,
        Concluido = 2
    }

    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketStatus Status { get; set; } = TicketStatus.Aberto;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
