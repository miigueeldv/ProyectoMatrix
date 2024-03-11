using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrix
{
    internal class Matrix
    {
        Personajes[,] tablero;
        int tamaño;
        Personajes Generico;
        Neo Neo;
        Smith Smith;
        int contador;
        public Matrix(int tamaño)
        {
            this.tablero = new Personajes[tamaño, tamaño];
            this.tamaño = tamaño;
            this.contador = 1;
        }

        public void tiempo()
        {
            this.contador++;
        }
        public int getTiempo()
        {
            return contador;
        }
        public void turnoSmith()
        {

            int fn = Smith.getlatitud();
            int cn = Smith.getlongitud();

            //Si no puede llegar a Neo con movimientos de alfil, no hace nada
            if (((Neo.getlatitud() + Neo.getlongitud()) %2) == ((Smith.getlatitud() + Smith.getlongitud()) %2))
            {
                int distancia = Math.Max(Math.Abs((Neo.getlatitud() - Smith.getlatitud())),Math.Abs((Neo.getlongitud() - Smith.getlongitud())));

                int cantidadinfectar =Smith.CantidadMaximaQuePodemosInfectar();

                //Esto es el aleatorio que se genera en Smith, quiere decir que tiene una cantidad de bajas maxima, no que vaya a hacerlo Smith.CantidadMaximaQuePodemosInfectar();
                Console.WriteLine("En este turno Smith tiene una capacidad maxima de " + cantidadinfectar+ " victimas");
                int contadormuertos = 0;
                for (int i = 0; i < distancia; i++) {

                    if (Smith.getlongitud() <= Neo.getlongitud())
                    {
                        cn += 1;
                    }
                    else
                    {
                        cn -= 1;
                    }

                    if (Smith.getlatitud() <= Neo.getlatitud())
                    {
                        fn += 1;
                    }
                    else
                    {
                        fn -= 1;
                    }

                        if (dentroMatriz(fn, cn))
                        {
                           if (tablero[fn, cn] != null) {
                                if (tablero[fn, cn].getCaracter() != 'N') {
                                    if (Smith.getInfectados() < cantidadinfectar)
                                    {
                                        tablero[fn, cn] = null;
                                        contadormuertos++;
                                        Smith.infectaruno();
                                    }
                                }
                            }
                        }
                }
                Console.WriteLine("Smith ha matado a " + contadormuertos);
            }
            else
            {
                Console.WriteLine("Smith NO puede hacer nada");
            }
            
            
        }
        public void turnoNeo()
        {
            Boolean es = Neo.creerseElegido();
            if (es)
            {
                revivir();
                int fn = Utilidades.aleatorio(0, tablero.GetLength(0) - 1);
                int cn = Utilidades.aleatorio(0, tablero.GetLength(1) - 1);

                int fa = Neo.getlatitud();
                int ca = Neo.getlongitud();
                if (tablero[fn, cn] == null)
                {
                    tablero[fa, ca] = null;
                }
                else
                {
                    tablero[fa, ca] = tablero[fn, cn];
                }
                tablero[fn, cn] = Neo;
                Neo.setLocalizacion(fn, cn);
            }
        }
        public void turnoGenerico()
        {

        }

        public ArrayList crearPersonajes()
        {
            ArrayList listapersonajes = new ArrayList();

            return listapersonajes;
        }

        //Iniciamos la simulacion añadiendio los personajes a Matrix
        public void inicioSimulacion()
        {
            Personajes[] listapersonajes = new Personajes[this.tamaño * this.tamaño];
            for (int i = 0; i < listapersonajes.Length; i++)
            {
                this.Generico = new Personajes();
                listapersonajes[i] = Generico;
            }

            int f = 0;
            int c = 0;
            int contador = 0;
            for (int fi = 0; fi < tablero.GetLength(0); fi++)
            {
                for (int co = 0; co < tablero.GetLength(1); co++)
                {
                    tablero[fi, co] = listapersonajes[contador];
                    contador++;
                }
            }
            this.Neo = new Neo();
            f = Utilidades.aleatorio(0, tablero.GetLength(0) - 1);
            c = Utilidades.aleatorio(0, tablero.GetLength(1) - 1);
            tablero[f, c] = Neo;
            tablero[f, c].setLocalizacion(f, c);

            this.Smith = new Smith();
            f = Utilidades.aleatorio(0, tablero.GetLength(0) - 1);
            c = Utilidades.aleatorio(0, tablero.GetLength(1) - 1);
            tablero[f, c] = Smith;
            tablero[f, c].setLocalizacion(f, c);

        }
        public void mostrarMatrix()
        {
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {

                    if (tablero[f, c] != null)
                    {
                        Console.Write(" " + tablero[f, c].getCaracter() + " ");
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine("");
            }
        }
        public void evaluarmuerte()
        {
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    //Debe tener algo en esa posicion
                    if (tablero[f, c] != null)
                    {
                        //Si el personaje tiene < 70 de muerte  y es una G de generico le sumamos 10
                        if (tablero[f, c].getPM() < 70 && tablero[f, c].getCaracter() == 'G')
                        {
                            tablero[f, c].setPM(10);
                        }
                        //Si el % de muerte es superior o igual a 70, lo sustituimos por null eso quiere decir que va a morir
                        if (tablero[f, c].getPM() >= 70)
                        {
                            tablero[f, c] = null;
                        }
                    }
                }
            }
        }
        public int[] comprobarAlrededorNeo()
        {
            int fn = Neo.getlatitud();
            int cn = Neo.getlongitud();
            int[] localizaciones = new int[16];
            //Los numeros pares filas, y los impares columnas, 0 con el 1, 2 con el 3
            localizaciones[0] = fn - 1;
            localizaciones[1] = cn - 1;

            localizaciones[2] = fn - 1;
            localizaciones[3] = cn;

            localizaciones[4] = fn - 1;
            localizaciones[5] = cn + 1;

            localizaciones[6] = fn;
            localizaciones[7] = cn - 1;

            localizaciones[8] = fn;
            localizaciones[9] = cn + 1;

            localizaciones[10] = fn + 1;
            localizaciones[11] = cn - 1;

            localizaciones[12] = fn + 1;
            localizaciones[13] = cn;

            localizaciones[14] = fn + 1;
            localizaciones[15] = cn + 1;

            return localizaciones;
        }

        public void revivir()
        {
            int[] posicion = comprobarAlrededorNeo();
            int fr;
            int cr;
            for (int i = 0; i < posicion.Length; i += 2)
            {
                fr = posicion[i];
                cr = posicion[i + 1];
                if (dentroMatriz(fr, cr))
                {

                    if (tablero[fr, cr] == null)
                    {
                        tablero[fr, cr] = new Personajes();
                    }

                }
            }
        }
        public Boolean dentroMatriz(int filas, int columnas)
        {
            Boolean dentro = false;
            if ((filas >= 0 && filas < tablero.GetLength(0)) && (columnas >= 0 && columnas < tablero.GetLength(1)))
            {
                dentro = true;
            }
            return dentro;
        }

        public Boolean quedaalguien()
        {
            Boolean queda = false;
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    if ((tablero[f, c]) != null)
                    {
                        if (!(tablero[f, c].getCaracter() == 'S') && !(tablero[f, c].getCaracter() == 'N'))
                        {
                            queda = true;
                        }
                    }
                }
            }
            return queda;
        }
    }
}
