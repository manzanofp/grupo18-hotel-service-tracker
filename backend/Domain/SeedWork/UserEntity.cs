using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.SeedWork;

public record UserEntity : BaseEntity
{
    protected UserEntity()
    {
    }

    public UserEntity(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public Email Email { get; private set; } = null!;
    public string Password { get; set; } = null!;
    public string[] Roles { get; set; } = null!;

    public GuestEntity? Guest { get; set; }
    public EmployeeEntity? Employee { get; set; }
}
