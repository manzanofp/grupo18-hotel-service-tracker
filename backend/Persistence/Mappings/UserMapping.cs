using Domain.Entities;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class UserMapping : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Email)
            .IsRequired();

        builder
            .Property(e => e.Roles)
            .IsRequired();

        builder
            .HasOne(u => u.Guest)
            .WithOne(g => g.User)
            .HasForeignKey<GuestEntity>(g => g.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(u => u.Employee)
            .WithOne(e => e.User)
            .HasForeignKey<EmployeeEntity>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
