using Domain.SeedWork;

namespace Domain.Entities;

public record EmployeeEntity : BaseEntity
{
    public long TicketId { get; set; }
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }    

    public IList<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();
    public UserEntity User { get; set; }
}