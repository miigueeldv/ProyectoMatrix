using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrix
{
    internal class Localizacion
    {
        int latitud;
        int longitud;
        String ciudad;

        public Localizacion(int latitud, int longitud)
        {
            //Fila
            this.latitud = latitud;
            //Columna
            this.longitud = longitud;
            this.ciudad = Utilidades.ciudadesaleatorio();
        }
        public int getLatitud() {  return latitud;  }
        public int getLongitud(){ return longitud;  }
        public String getCiudad() {  return ciudad; }

        //Columnas
        public void setLongitud(int columna)
        {
            longitud = columna;
        }
        //Filas
        public void setLatitud(int fila)
        {
            latitud = fila;
        }


    }
}
