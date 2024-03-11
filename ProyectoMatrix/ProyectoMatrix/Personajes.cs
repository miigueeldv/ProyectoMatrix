using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrix
{
    internal class Personajes
    {
        protected String nombre;
        protected Localizacion localizacion;
        protected int edad;
        protected int pm;
        protected char caracter;
        public Personajes()
        {
            this.nombre = Utilidades.nombresesaleatorio();
            this.edad = Utilidades.aleatorio(0,80);
            this.pm = Utilidades.aleatorio(0, 70);
            this.caracter = 'G';
        }

        public String getNombre() {  
            return nombre; 
        }
        public void setLocalizacion(int filas, int columna)
        {
            localizacion=new Localizacion(filas,columna);
        }
        //Filas
        public int getlatitud()
        {
            return localizacion.getLatitud();
        }
        //Columnas
        public int getlongitud()
        {
            return localizacion.getLongitud();
        }
        public String nombreCiudad()
        {
            return localizacion.getCiudad();
        }
        public void setPM(int num)
        {
            this.pm = this.pm + num;
        }
        public int getPM()
        {
            return pm;
        }
        public char getCaracter()
        {
            return caracter;
        }

    }
}
