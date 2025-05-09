using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

public class Simulacion
{
    public static long SimularSinHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones)
    {
        long aciertos = 0;
        for (int i = 0; i < cantidadSimulaciones; i++)
        {
            if (bolillero.Jugar(jugada))
                aciertos++;
        }
        return aciertos;
    }

    public static long SimularConHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulaciones, int cantidadHilos)
    {
        long aciertos = 0;
        int simulacionesPorHilo = cantidadSimulaciones / cantidadHilos;
        var tareas = new List<Task<long>>();
        
        for (int i = 0; i < cantidadHilos; i++)
        {
            var bolilleroClon = (Bolillero)bolillero.Clone();
            tareas.Add(Task.Run(() =>
            {
                long aciertosHilo = 0;
                for (int j = 0; j < simulacionesPorHilo; j++)
                {
                    if (bolilleroClon.Jugar(jugada))
                        aciertosHilo++;
                }
                return aciertosHilo;
            }));
        }

        Task.WaitAll(tareas.ToArray());
        
        foreach (var tarea in tareas)
        {
            aciertos += tarea.Result;
        }

        return aciertos;
    }
} 