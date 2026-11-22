using DatosAbiertos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatosAbiertos.Core.Data.Configurations;

public sealed class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable("municipios");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.IneCode).HasColumnName("ine_code").HasMaxLength(5).IsRequired();
        builder.HasIndex(x => x.IneCode).IsUnique();
        builder.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(200).IsRequired();
        builder.Property(x => x.ProvinciaId).HasColumnName("provincia_id");
        builder.HasOne(x => x.Provincia)
            .WithMany(x => x.Municipios)
            .HasForeignKey(x => x.ProvinciaId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Lat).HasColumnName("lat");
        builder.Property(x => x.Lon).HasColumnName("lon");
        builder.Property(x => x.Poblacion).HasColumnName("poblacion");
    }
}
