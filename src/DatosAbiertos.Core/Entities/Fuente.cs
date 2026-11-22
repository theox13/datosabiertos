namespace DatosAbiertos.Core.Entities;

public sealed class Fuente
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Slug { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Licencia { get; set; } = "CC BY 4.0";
    public string Formato { get; set; } = string.Empty;
    public string Frecuencia { get; set; } = string.Empty;
    public string CoberturaGeografica { get; set; } = string.Empty;
    public DateTimeOffset? LastAttemptAt { get; set; }
    public DateTimeOffset? LastSuccessAt { get; set; }
    public DateOnly? CoverageFrom { get; set; }
    public DateOnly? CoverageTo { get; set; }
    public string Status { get; set; } = "unknown";
    public string? Notes { get; set; }

    public ICollection<Farmacia> Farmacias { get; set; } = [];
    public ICollection<Guardia> Guardias { get; set; } = [];
    public ICollection<RawPayload> RawPayloads { get; set; } = [];
    public ICollection<IngestRun> IngestRuns { get; set; } = [];
}
