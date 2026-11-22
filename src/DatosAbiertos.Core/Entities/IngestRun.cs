namespace DatosAbiertos.Core.Entities;

public sealed class IngestRun
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid SourceId { get; set; }
    public Fuente? Source { get; set; }
    public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? FinishedAt { get; set; }
    public string Status { get; set; } = "running";
    public int RowsRead { get; set; }
    public int RowsUpserted { get; set; }
    public string? Error { get; set; }
}
