using Domain.SeedWork;

namespace Domain.Entities;

public record EmployeeEntity : BaseEntity
{
    public long TicketId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }    
    public string Password { get; set; }

    //relationships
    public IList<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();
}