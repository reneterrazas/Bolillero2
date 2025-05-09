using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Tests;

public class SimulacionTests
{
    private Bolillero bolillero;
    private Primero primero;

    public SimulacionTests()
    {
        bolillero = new Bolillero(10);
        primero = new Primero();
        bolillero.SetAzar(primero);
    }

    [Fact]
    public void SimularSinHilos_ConJugadaCorrecta_DevuelveCantidadCorrecta()
    {
        var jugada = new List<int> { 0, 1 };
        long aciertos = Simulacion.SimularSinHilos(bolillero, jugada, 1);
        Assert.Equal(1, aciertos);
    }

    [Fact]
    public void SimularConHilos_ConJugadaCorrecta_DevuelveCantidadCorrecta()
    {
        var jugada = new List<int> { 0, 1 };
        long aciertos = Simulacion.SimularConHilos(bolillero, jugada, 2, 2);
        Assert.Equal(2, aciertos);
    }

    [Fact]
    public void Bolillero_Clone_CreaCopiaExacta()
    {
        bolillero.SacarBolilla();
        var clon = (Bolillero)bolillero.Clone();
        Assert.Equal(bolillero.CantidadBolillasDentro, clon.CantidadBolillasDentro);
        Assert.Equal(bolillero.CantidadBolillasFuera, clon.CantidadBolillasFuera);
    }
} 