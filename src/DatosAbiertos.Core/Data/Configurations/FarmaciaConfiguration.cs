using DatosAbiertos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatosAbiertos.Core.Data.Configurations;

public sealed class FarmaciaConfiguration : IEntityTypeConfiguration<Farmacia>
{
    public void Configure(EntityTypeBuilder<Farmacia> builder)
    {
        builder.ToTable("farmacias");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ProvinciaId).HasColumnName("provincia_id");
        builder.HasOne(x => x.Provincia)
            .WithMany(x => x.Farmacias)
            .HasForeignKey(x => x.ProvinciaId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.SoeCode).HasColumnName("soe_code").HasMaxLength(20);
        builder.HasIndex(x => new { x.ProvinciaId, x.SoeCode })
            .IsUnique()
            .HasFilter("soe_code IS NOT NULL");
        builder.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Direccion).HasColumnName("direccion").HasMaxLength(300);
        builder.Property(x => x.MunicipioId).HasColumnName("municipio_id");
        builder.HasOne(x => x.Municipio)
            .WithMany(x => x.Farmacias)
            .HasForeignKey(x => x.MunicipioId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Lat).HasColumnName("lat");
        builder.Property(x => x.Lon).HasColumnName("lon");
        builder.Property(x => x.Telefono).HasColumnName("telefono").HasMaxLength(30);
        builder.Property(x => x.SourceId).HasColumnName("source_id");
        builder.HasOne(x => x.Source)
            .WithMany(x => x.Farmacias)
            .HasForeignKey(x => x.SourceId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.ExternalId).HasColumnName("external_id").HasMaxLength(100).IsRequired();
        builder.HasIndex(x => new { x.SourceId, x.ExternalId }).IsUnique();
        builder.Property(x => x.Fingerprint).HasColumnName("fingerprint").HasMaxLength(64).IsRequired();
        builder.HasIndex(x => x.Fingerprint).IsUnique();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
    }
}
