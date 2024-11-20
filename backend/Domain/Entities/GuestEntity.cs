using Domain.SeedWork;

namespace Domain.Entities;

public record GuestEntity : BaseEntity
{
    public long GuestId { get; init; }
    public string Name { get; init; }
    public string Password { get; set; }

    public IList<TicketEntity> Tickets { get; init; } = new List<TicketEntity>();
}