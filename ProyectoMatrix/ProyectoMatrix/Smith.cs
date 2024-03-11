using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrix
{
    internal class Smith : Personajes
    {
        //Porcentaje infectar
        int infectar;
        int infectados;
        public Smith()
        {
            this.nombre = "Smith";
            this.infectar = 0;
            this.pm = 0;
            this.caracter = 'S';
            this.infectados = 0;
        }
        //Numero de victimas maximas que puede hacer en un turno
        public int CantidadMaximaQuePodemosInfectar()
        {
            this.infectar = Utilidades.aleatorio(0, 5);
            this.infectados = 0;
            return this.infectar;
        }

        //Contador de victimas
        public void infectaruno()
        {
            this.infectados++;
        }

        //Ver cuantas victimas tiene
        public int getInfectados()
        {
            return this.infectados;
        }
    }
}
