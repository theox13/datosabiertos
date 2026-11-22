using DatosAbiertos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatosAbiertos.Core.Data.Configurations;

public sealed class RawPayloadConfiguration : IEntityTypeConfiguration<RawPayload>
{
    public void Configure(EntityTypeBuilder<RawPayload> builder)
    {
        builder.ToTable("raw_payloads");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.SourceId).HasColumnName("source_id");
        builder.HasOne(x => x.Source)
            .WithMany(x => x.RawPayloads)
            .HasForeignKey(x => x.SourceId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.FetchedAt).HasColumnName("fetched_at");
        builder.Property(x => x.Url).HasColumnName("url").HasMaxLength(500).IsRequired();
        builder.Property(x => x.HttpStatus).HasColumnName("http_status");
        builder.Property(x => x.ContentHash).HasColumnName("content_hash").HasMaxLength(64).IsRequired();
        builder.Property(x => x.Content).HasColumnName("content").HasColumnType("text").IsRequired();
        builder.HasIndex(x => new { x.SourceId, x.FetchedAt });
    }
}
