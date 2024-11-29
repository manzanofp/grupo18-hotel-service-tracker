using Domain.SeedWork;

namespace Domain.Entities;

public record GuestEntity : BaseEntity
{
    public long GuestId { get; init; }
    public long UserId { get; init; }
    public string Name { get; init; } = string.Empty;

    public IList<TicketEntity> Tickets { get; init; } = new List<TicketEntity>();
    public UserEntity User { get; init; } = null!;
}