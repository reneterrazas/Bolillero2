using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Tests;

public class Primero : IAzar
{
    public int ObtenerNumeroAleatorio(int min, int max)
    {
        return min;
    }
} 
