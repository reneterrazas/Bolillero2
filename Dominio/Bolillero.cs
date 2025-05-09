using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

public class Bolillero : ICloneable
{
    private List<int> bolillasDentro;
    private List<int> bolillasFuera;
    private IAzar azar;

    public Bolillero(int cantidadBolillas)
    {
        bolillasDentro = Enumerable.Range(0, cantidadBolillas).ToList();
        bolillasFuera = new List<int>();
    }

    public void SetAzar(IAzar azar)
    {
        this.azar = azar;
    }

    public int SacarBolilla()
    {
        if (bolillasDentro.Count == 0)
            throw new InvalidOperationException("No hay bolillas disponibles");

        int indice = azar.ObtenerNumeroAleatorio(0, bolillasDentro.Count);
        int bolilla = bolillasDentro[indice];
        bolillasDentro.RemoveAt(indice);
        bolillasFuera.Add(bolilla);
        return bolilla;
    }

    public void ReingresarBolillas()
    {
        bolillasDentro.AddRange(bolillasFuera);
        bolillasFuera.Clear();
    }

    public bool Jugar(List<int> jugada)
    {
        ReingresarBolillas();
        foreach (int bolilla in jugada)
        {
            if (SacarBolilla() != bolilla)
                return false;
        }
        return true;
    }

    public int JugarNVeces(List<int> jugada, int cantidad)
    {
        int aciertos = 0;
        for (int i = 0; i < cantidad; i++)
        {
            if (Jugar(jugada))
                aciertos++;
        }
        return aciertos;
    }

    public int CantidadBolillasDentro => bolillasDentro.Count;
    public int CantidadBolillasFuera => bolillasFuera.Count;

    public object Clone()
    {
        Bolillero clon = new Bolillero(0);
        clon.bolillasDentro = new List<int>(bolillasDentro);
        clon.bolillasFuera = new List<int>(bolillasFuera);
        clon.azar = azar;
        return clon;
    }
}