using DatosAbiertos.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatosAbiertos.Core.Data;

public sealed class DatosAbiertosDbContext(DbContextOptions<DatosAbiertosDbContext> options)
    : DbContext(options)
{
    public DbSet<Fuente> Fuentes => Set<Fuente>();
    public DbSet<Provincia> Provincias => Set<Provincia>();
    public DbSet<Municipio> Municipios => Set<Municipio>();
    public DbSet<Farmacia> Farmacias => Set<Farmacia>();
    public DbSet<Guardia> Guardias => Set<Guardia>();
    public DbSet<RawPayload> RawPayloads => Set<RawPayload>();
    public DbSet<IngestRun> IngestRuns => Set<IngestRun>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatosAbiertosDbContext).Assembly);
    }
}
