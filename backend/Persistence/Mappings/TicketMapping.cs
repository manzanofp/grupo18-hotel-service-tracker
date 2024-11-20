using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class TicketMapping : IEntityTypeConfiguration<TicketEntity>
{
    public void Configure(EntityTypeBuilder<TicketEntity> builder)
    {
        builder
            .HasKey(e => e.Id);
        builder
            .Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder
            .Property(e => e.Cpf).IsRequired().HasMaxLength(11);
        builder
            .Property(e => e.RoomNumber).IsRequired().HasMaxLength(1000);
        builder
            .Property(e => e.Description).IsRequired().HasMaxLength(200);
        builder
            .Property(e => e.Address).IsRequired().HasMaxLength(200);
        builder
            .Property(e => e.ProblemType).IsRequired().HasMaxLength(200).HasConversion<string>();
        builder
            .Property(e => e.CreatedAt).IsRequired();
        builder
            .Property(e => e.Status).IsRequired().HasMaxLength(20).HasConversion<string>();
        builder
            .Property(e => e.IsFinished).IsRequired();

        builder
            .HasOne(e => e.Guest)
              .WithMany(h => h.Tickets)
              .HasForeignKey(e => e.GuestId);

        builder.HasOne(e => e.Employee)
              .WithMany(f => f.Tickets)
              .HasForeignKey(e => e.EmployeeId);
    }
}
