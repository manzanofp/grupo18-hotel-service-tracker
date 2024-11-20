using Domain.Enums;
using Domain.SeedWork;

namespace Domain.Entities;

public record TicketEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Email { get; set; } = null!;
    public long RoomNumber { get; set; }
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public EProblemStatus Status { get; set; }
    public EProblemTypes ProblemType { get; set; }
    public bool IsFinished { get; set; }

    public long GuestId { get; set; }
    public GuestEntity Guest { get; set; } = null!;
    
    public long? EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;
}