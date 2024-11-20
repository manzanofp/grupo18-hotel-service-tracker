namespace Domain.SeedWork;

public abstract record BaseEntity
{
    private long _Id;
    private DateTime _CreatedAt;
    private DateTime? _UpdatedAt;
    private DateTime? _DeletedAt;

    protected BaseEntity()
    {
        _Id = Id;
        _CreatedAt = CreatedAt;
    }
    
    public long Id { get => _Id; set => _Id = value; }
    public DateTime CreatedAt { get => _CreatedAt; set => _CreatedAt = value; } 
    public DateTime? UpdatedAt { get => _UpdatedAt; set => _UpdatedAt = value; } 
    public DateTime? DeleteAt { get => _DeletedAt; set => _DeletedAt = value; } 
}