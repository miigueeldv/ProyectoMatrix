using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrix
{
    internal class Neo : Personajes
    {
        Boolean elegido;
        public Neo()
        {
            this.nombre = "Neo";
            this.elegido = false;
            this.pm = 0;
            this.caracter = 'N';
        }

        public Boolean creerseElegido()
        {
            int num = Utilidades.aleatorio(0, 2);
                    if (num == 0)
                {
                    this.elegido = false;
                    Console.WriteLine("Neo no es el elegido!");
                }
                    else
                {
                    this.elegido = true;
                    Console.WriteLine("Neo es el elegido!");
                }
            return elegido;
        } 

    }
}
