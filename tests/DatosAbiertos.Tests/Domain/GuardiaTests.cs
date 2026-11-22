using DatosAbiertos.Core.Entities;

namespace DatosAbiertos.Tests.Domain;

public class GuardiaTests
{
    private static readonly DateTimeOffset Inicio = new(2026, 11, 22, 8, 0, 0, TimeSpan.FromHours(1));
    private static readonly DateTimeOffset Fin = new(2026, 11, 22, 22, 0, 0, TimeSpan.FromHours(1));

    [Theory]
    [InlineData(7, 59, false)]
    [InlineData(8, 0, true)]
    [InlineData(12, 30, true)]
    [InlineData(21, 59, true)]
    [InlineData(22, 0, false)]
    public void EstaVigente_CompruebaLaVentana(int hora, int minuto, bool esperado)
    {
        var guardia = new Guardia
        {
            ValidFrom = Inicio,
            ValidTo = Fin
        };

        var ahora = new DateTimeOffset(2026, 11, 22, hora, minuto, 0, TimeSpan.FromHours(1));

        Assert.Equal(esperado, guardia.EstaVigente(ahora));
    }
}
