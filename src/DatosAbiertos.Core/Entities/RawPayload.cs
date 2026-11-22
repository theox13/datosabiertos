namespace DatosAbiertos.Core.Entities;

public sealed class RawPayload
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid SourceId { get; set; }
    public Fuente? Source { get; set; }
    public DateTimeOffset FetchedAt { get; set; } = DateTimeOffset.UtcNow;
    public string Url { get; set; } = string.Empty;
    public int HttpStatus { get; set; }
    public string ContentHash { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
