using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Tests;

public class BolilleroTests
{
    private Bolillero bolillero;
    private Primero primero;

    public BolilleroTests()
    {
        bolillero = new Bolillero(10);
        primero = new Primero();
        bolillero.SetAzar(primero);
    }

    [Fact]
    public void SacarBolilla_DevuelvePrimeraBolilla()
    {
        int bolilla = bolillero.SacarBolilla();
        Assert.Equal(0, bolilla);
        Assert.Equal(9, bolillero.CantidadBolillasDentro);
        Assert.Equal(1, bolillero.CantidadBolillasFuera);
    }

    [Fact]
    public void ReingresarBolillas_DevuelveTodasLasBolillas()
    {
        bolillero.SacarBolilla();
        bolillero.ReingresarBolillas();
        Assert.Equal(10, bolillero.CantidadBolillasDentro);
        Assert.Equal(0, bolillero.CantidadBolillasFuera);
    }

    [Fact]
    public void JugarGana_ConJugadaCorrecta_DevuelveTrue()
    {
        var jugada = new List<int> { 0, 1, 2, 3 };
        bool resultado = bolillero.Jugar(jugada);
        Assert.True(resultado);
    }

    [Fact]
    public void JugarPierde_ConJugadaIncorrecta_DevuelveFalse()
    {
        var jugada = new List<int> { 4, 2, 1 };
        bool resultado = bolillero.Jugar(jugada);
        Assert.False(resultado);
    }

    [Fact]
    public void JugarNVeces_ConJugadaCorrecta_DevuelveCantidadCorrecta()
    {
        var jugada = new List<int> { 0, 1 };
        int aciertos = bolillero.JugarNVeces(jugada, 1);
        Assert.Equal(1, aciertos);
    }
}