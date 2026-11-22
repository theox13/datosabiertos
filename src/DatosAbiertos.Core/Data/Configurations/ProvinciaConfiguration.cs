using DatosAbiertos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatosAbiertos.Core.Data.Configurations;

public sealed class ProvinciaConfiguration : IEntityTypeConfiguration<Provincia>
{
    public void Configure(EntityTypeBuilder<Provincia> builder)
    {
        builder.ToTable("provincias");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.IneCode).HasColumnName("ine_code").HasMaxLength(5).IsRequired();
        builder.HasIndex(x => x.IneCode).IsUnique();
        builder.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Ccaa).HasColumnName("ccaa").HasMaxLength(100).IsRequired();
    }
}
