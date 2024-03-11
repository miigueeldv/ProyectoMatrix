using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrix
{
    internal class Utilidades
    {
        private static readonly Random r = new Random();
        private static readonly object syncLock = new object();

        public static int aleatorio(int min, int max)
        {
            lock (syncLock)
            {
                return r.Next(min, max);
            }
        }

        public static String ciudadesaleatorio()
        {
            lock (syncLock)
            {
                String[] ciudades = {
                    "Nueva York",
                    "Pekín",
                    "Roma",
                    "Paris",
                    "Londres",
                    "Caracuel"
                };
                int aleatorio = r.Next(0, ciudades.Length - 1);

                return ciudades[aleatorio];

            }
        }

        public static String nombresesaleatorio()
        {
            lock (syncLock)
            {
                String[] nombres = {
                    "Pepe",
                    "Juan",
                    "Ana",
                    "Sonia",
                    "Pedro",
                    "Chiquito",
                    "Elena"
                };
                int aleatorio = r.Next(0, nombres.Length - 1);

                return nombres[aleatorio];
            }
        }
        public static String pedirTeclado()
        {
            String cadena = Console.ReadLine();
            return cadena;
        }
    }
}