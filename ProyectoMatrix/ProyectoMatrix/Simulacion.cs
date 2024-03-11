using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrix
{
    internal class Simulacion
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Introduce un tamaño para la matriz, minimo de 5");
            String cadena = Utilidades.pedirTeclado();
            int num;

            if (cadena.Equals(""))
            {
                Console.WriteLine("ERROR, debes introducir un tamaño para la matriz");
            }
            else if (!(int.TryParse(cadena, out num )))
            {
                Console.WriteLine("ERROR, debes introducir un numero entero");
            }
            else if (Int32.Parse(cadena) < 5)
            {
                Console.WriteLine("ERROR, la matriz debe tener un tamaño minimo de 5");
            }
            else {  
                Matrix simulacion = new Matrix(Int32.Parse(cadena));
                simulacion.inicioSimulacion();

                Console.WriteLine("BIENVENIDO A MATRIX , PULSA ENTER PARA EMPEZAR LA SIMULACION");
                simulacion.mostrarMatrix();
                Console.ReadLine();

                    while (simulacion.getTiempo() <= 20 && simulacion.quedaalguien()) {

                        simulacion.evaluarmuerte();

                        if (simulacion.getTiempo() % 2 == 0)
                        {
                            simulacion.turnoSmith();
                        }

                        if (simulacion.getTiempo() % 5 == 0)
                        {
                            simulacion.turnoNeo();
                        }

                        simulacion.tiempo();
                        simulacion.mostrarMatrix();
                        Console.WriteLine();
                        Console.ReadLine();
                }

                if (simulacion.quedaalguien())
                {
                    simulacion.mostrarMatrix();
                    Console.WriteLine("Has ganado!");
                }
                else
                {
                    simulacion.mostrarMatrix();
                    Console.WriteLine("Has perdido, solo quedan Neo y Smith");
                }
            }
            Console.ReadLine();
        }
    }
}
