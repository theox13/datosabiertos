namespace DatosAbiertos.Core.Entities;

public sealed class Guardia
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid FarmaciaId { get; set; }
    public Farmacia? Farmacia { get; set; }
    public Guid SourceId { get; set; }
    public Fuente? Source { get; set; }
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset ValidTo { get; set; }
    public string RawHash { get; set; } = string.Empty;
    public DateTimeOffset LastVerifiedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public bool EstaVigente(DateTimeOffset ahora) => ahora >= ValidFrom && ahora < ValidTo;
}
