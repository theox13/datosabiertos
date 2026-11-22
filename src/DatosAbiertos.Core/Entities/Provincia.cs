namespace DatosAbiertos.Core.Entities;

public sealed class Provincia
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string IneCode { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Ccaa { get; set; } = string.Empty;

    public ICollection<Municipio> Municipios { get; set; } = [];
    public ICollection<Farmacia> Farmacias { get; set; } = [];
}
