namespace DatosAbiertos.Core.Entities;

public sealed class Farmacia
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid ProvinciaId { get; set; }
    public Provincia? Provincia { get; set; }
    public string? SoeCode { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Direccion { get; set; }
    public Guid? MunicipioId { get; set; }
    public Municipio? Municipio { get; set; }
    public double? Lat { get; set; }
    public double? Lon { get; set; }
    public string? Telefono { get; set; }
    public Guid SourceId { get; set; }
    public Fuente? Source { get; set; }
    public string ExternalId { get; set; } = string.Empty;
    public string Fingerprint { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<Guardia> Guardias { get; set; } = [];
}
