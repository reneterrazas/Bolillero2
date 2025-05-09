using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

public class AzarRandom : IAzar
{
    private Random random;

    public AzarRandom()
    {
        random = new Random();
    }

    public int ObtenerNumeroAleatorio(int min, int max)
    {
        return random.Next(min, max);
    }
} 