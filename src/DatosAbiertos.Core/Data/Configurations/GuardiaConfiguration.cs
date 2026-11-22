using DatosAbiertos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatosAbiertos.Core.Data.Configurations;

public sealed class GuardiaConfiguration : IEntityTypeConfiguration<Guardia>
{
    public void Configure(EntityTypeBuilder<Guardia> builder)
    {
        builder.ToTable("guardias");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.FarmaciaId).HasColumnName("farmacia_id");
        builder.HasOne(x => x.Farmacia)
            .WithMany(x => x.Guardias)
            .HasForeignKey(x => x.FarmaciaId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.SourceId).HasColumnName("source_id");
        builder.HasOne(x => x.Source)
            .WithMany(x => x.Guardias)
            .HasForeignKey(x => x.SourceId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.ValidFrom).HasColumnName("valid_from");
        builder.Property(x => x.ValidTo).HasColumnName("valid_to");
        builder.Property(x => x.RawHash).HasColumnName("raw_hash").HasMaxLength(64).IsRequired();
        builder.Property(x => x.LastVerifiedAt).HasColumnName("last_verified_at");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.HasIndex(x => new { x.FarmaciaId, x.SourceId, x.ValidFrom }).IsUnique();
        builder.HasIndex(x => new { x.ValidFrom, x.ValidTo });
    }
}
