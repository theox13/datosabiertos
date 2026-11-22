using DatosAbiertos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatosAbiertos.Core.Data.Configurations;

public sealed class FuenteConfiguration : IEntityTypeConfiguration<Fuente>
{
    public void Configure(EntityTypeBuilder<Fuente> builder)
    {
        builder.ToTable("fuentes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Slug).HasColumnName("slug").HasMaxLength(100).IsRequired();
        builder.HasIndex(x => x.Slug).IsUnique();
        builder.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Url).HasColumnName("url").HasMaxLength(500).IsRequired();
        builder.Property(x => x.Licencia).HasColumnName("licencia").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Formato).HasColumnName("formato").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Frecuencia).HasColumnName("frecuencia").HasMaxLength(50).IsRequired();
        builder.Property(x => x.CoberturaGeografica).HasColumnName("cobertura_geografica").HasMaxLength(200).IsRequired();
        builder.Property(x => x.LastAttemptAt).HasColumnName("last_attempt_at");
        builder.Property(x => x.LastSuccessAt).HasColumnName("last_success_at");
        builder.Property(x => x.CoverageFrom).HasColumnName("coverage_from");
        builder.Property(x => x.CoverageTo).HasColumnName("coverage_to");
        builder.Property(x => x.Status).HasColumnName("status").HasMaxLength(30).IsRequired();
        builder.Property(x => x.Notes).HasColumnName("notes").HasMaxLength(1000);
    }
}
