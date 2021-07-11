using System;

namespace SimuladorCarrera
{

    class Program
    {
        public enum Caracteristica
        {
            Audaz = 1,
            Oportunista
        }
        public enum Color
        {
            Rojo = 1,
            Verde,
            Azul,
            Amarillo,
            Celeste,
            Rosa,
            Violeta,
            Gris,
            Naranja,
            Bordo
        }

        public enum Marcas
        {
            BMW = 1,
            Peugeot,
            Renault,
            Chevrolet,
            Ford

        }


        static Random rnd = new Random();

        /// <summary>
        /// Se encarga de inicar las matrices, arrays y variables del main
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="puntaje"></param>
        /// <param name="posicionUltimaCarrera"></param>
        /// <param name="idPosUltimaCarrera"></param>
        public static void IniciarVariables(string[,] corredores, int[,] carreras, int[] puntaje, int[] posicionUltimaCarrera, string[] idPosUltimaCarrera)
        {
            int[] pos = new int[10];

            #region llenadoMatrizCorredores

            corredores[0, 0] = "7";
            corredores[0, 1] = "Mateo";
            corredores[0, 2] = Caracteristica.Audaz.ToString();
            corredores[0, 3] = Marcas.Chevrolet.ToString();
            corredores[0, 4] = Color.Amarillo.ToString();

            corredores[1, 0] = "99";
            corredores[1, 1] = "Mariana";
            corredores[1, 2] = Caracteristica.Oportunista.ToString();
            corredores[1, 3] = Marcas.Renault.ToString();
            corredores[1, 4] = Color.Rojo.ToString();

            corredores[2, 0] = "14";
            corredores[2, 1] = "Roberto";
            corredores[2, 2] = Caracteristica.Audaz.ToString();
            corredores[2, 3] = Marcas.BMW.ToString();
            corredores[2, 4] = Color.Azul.ToString();

            corredores[3, 0] = "23";
            corredores[3, 1] = "Paola";
            corredores[3, 2] = Caracteristica.Audaz.ToString();
            corredores[3, 3] = Marcas.Ford.ToString();
            corredores[3, 4] = Color.Gris.ToString();

            corredores[4, 0] = "41";
            corredores[4, 1] = "Franco";
            corredores[4, 2] = Caracteristica.Oportunista.ToString();
            corredores[4, 3] = Marcas.Chevrolet.ToString();
            corredores[4, 4] = Color.Verde.ToString();

            corredores[5, 0] = "1";
            corredores[5, 1] = "Erika";
            corredores[5, 2] = Caracteristica.Audaz.ToString();
            corredores[5, 3] = Marcas.BMW.ToString();
            corredores[5, 4] = Color.Violeta.ToString();

            corredores[6, 0] = "27";
            corredores[6, 1] = "lautaro";
            corredores[6, 2] = Caracteristica.Oportunista.ToString();
            corredores[6, 3] = Marcas.Peugeot.ToString();
            corredores[6, 4] = Color.Rosa.ToString();

            for (int i = 0; i < corredores.GetLength(0); i++)
            {
                if (corredores[i, 0] == null)
                {

                    corredores[i, 0] = "-1";

                    for (int j = 1; j < corredores.GetLength(1); j++)
                    {
                        corredores[i, j] = "EspacioDisponible";
                    }
                }
            }

            #endregion

            #region llenadoMatrizCarreras

            int[] puntajeFinal = new int[10];

            for (int i = 0; i < carreras.GetLength(0); i++)
            {
                for (int j = 0; j < carreras.GetLength(1); j++)
                {
                    carreras[i, j] = -1;
                }
            }



            for (int i = 0; i < carreras.GetLength(1); i++)
            {
                pos = Helper.PosRandomSinRepetir(pos, corredores);

                for (int j = 0; j < carreras.GetLength(0); j++)
                {
                    if (i == 0)
                    {

                        carreras[j, i] = Convert.ToInt32(corredores[j, i]);


                    }
                    else if (i == (carreras.GetLength(1) - 1))
                    {

                        carreras[j, i] = puntajeFinal[j];
                    }
                    else
                    {

                        if (pos[j] > 0)
                        {
                            carreras[j, i] = pos[j];

                            puntajeFinal[j] += puntaje[(pos[j] - 1)];

                        }
                        else
                        {
                            puntajeFinal[j] = -1;
                        }

                    }

                }
            }

            #endregion

            #region llenarMatrizUltimaCarreraYID

            for (int i = 0; i < posicionUltimaCarrera.Length; i++)
            {

                posicionUltimaCarrera[i] = carreras[i, 3];

            }

            for (int i = 0; i < idPosUltimaCarrera.Length; i++)
            {

                idPosUltimaCarrera[i] = corredores[i, 0];

            }

            #endregion

        }

        #region ExplicacionApp

        /*
         La aplicación es un juego de carreras en donde podemos hacer ABM de corredores, buscar por nombre o id y mostrar sus posiciones.
        Consiste en que los corredores dados de alta juegan 3 carreras por temporada. Al finalizar la temporada se muestra al campeón.
        En el menú carrera se encuentra Nueva Temporada para iniciar una nueva y volver a correr las 3 carreras y tenemos la opción carrera
        para jugar la carrera correspondiente hasta 3 por temporada. Luego de finalizada una carrera se contabilizan el puntaje según el array puntaje y se añade
        el mismo al correrdor correspondiente. El campeón se determina por el que obtuvo el mayor puntaje.

         */

        #endregion


        static void Main(string[] args)
        {
            #region Declaracion

            //                 1, 2,  3, 4, 5, 6, 7, 8, ,9, 10
            int[] puntaje = { 15, 10, 8, 7, 6, 5, 4, 3, 2, 1 };
            //id- Nombre- Carac- Marca -Color
            string[,] corredores = new string[10, 5];
            //id  c1(pos) c2(pos) c3(pos) PuntajeFinal
            int[,] carreras = new int[10, 5];
            int[] posicionUltimaCarrera = new int[10];
            string[] idPosUltimaCarrera = new string[10];
            int numCarrera = 4;
            string auto = "├┌┐/\\┌┐┤";

            #endregion

            Console.WindowWidth = Console.LargestWindowWidth;

            IniciarVariables(corredores, carreras, puntaje, posicionUltimaCarrera, idPosUltimaCarrera);

            Menu.Principal(corredores, carreras, puntaje, posicionUltimaCarrera, idPosUltimaCarrera, auto, ref numCarrera);





        }
    }
}
