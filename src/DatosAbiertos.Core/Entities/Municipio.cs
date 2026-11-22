namespace DatosAbiertos.Core.Entities;

public sealed class Municipio
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string IneCode { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public Guid ProvinciaId { get; set; }
    public Provincia? Provincia { get; set; }
    public double? Lat { get; set; }
    public double? Lon { get; set; }
    public int? Poblacion { get; set; }

    public ICollection<Farmacia> Farmacias { get; set; } = [];
}
