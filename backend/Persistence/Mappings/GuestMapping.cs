using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings;

public class GuestMapping : IEntityTypeConfiguration<GuestEntity>
{
    public void Configure(EntityTypeBuilder<GuestEntity> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Name).IsRequired()
            .HasMaxLength(100);

        builder
            .HasMany(g => g.Tickets)
            .WithOne()
            .HasForeignKey(t => t.GuestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
