using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorCarrera
{
    class Helper
    {
        static Random rnd = new Random();

        /// <summary>
        /// Devuelve un array con posiciones Random pero que no están repetidas recibiendo la matriz corredores
        /// </summary>
        /// <param name="arrayPos"></param>
        /// <param name="corredores"></param>
        /// <returns></returns>
        public static int[] PosRandomSinRepetir(int[] arrayPos, string[,] corredores)
        {
            bool posRepetida = false;
            int posAux = 0;
            int[] pos = new int[arrayPos.Length];



            for (int i = 0; i < pos.Length; i++)
            {

                pos[i] = -1;

            }


            for (int i = 0; i < Corredores.ContarCorredoresActuales(corredores); i++)
            {

                if (i == 0)
                {

                    pos[i] = rnd.Next(1, Corredores.ContarCorredoresActuales(corredores) + 1);

                }
                else
                {

                    do
                    {

                        posRepetida = false;

                        posAux = rnd.Next(1, Corredores.ContarCorredoresActuales(corredores) + 1);


                        for (int j = 0; j < Corredores.ContarCorredoresActuales(corredores); j++)
                        {

                            if (posAux == pos[j])
                            {

                                posRepetida = true;

                                break;

                            }

                        }

                        if (!posRepetida)
                        {

                            pos[i] = posAux;

                        }


                    } while (posRepetida);


                }

            }

            return pos;

        }

        /// <summary>
        /// Devuelve un array con posiciones Random pero que no están repetidas utilzando el array de posiciones y el array de id de corredores
        /// </summary>
        /// <param name="arrayPos"></param>
        /// <param name="corredores"></param>
        /// <returns></returns>
        public static int[] PosRandomParaVueltaCarrera(int[] arrayPos, string[] corredores)
        {
            bool posRepetida = false;
            int posAux = 0;
            int[] pos = new int[arrayPos.Length];



            for (int i = 0; i < pos.Length; i++)
            {

                pos[i] = -1;

            }

            for (int i = 0; i < CantidadCorredoresArray(corredores); i++)
            {

                if (i == 0)
                {

                    pos[i] = rnd.Next(1, CantidadCorredoresArray(corredores) + 1);

                }
                else
                {

                    do
                    {

                        posRepetida = false;

                        posAux = rnd.Next(1, CantidadCorredoresArray(corredores) + 1);


                        for (int j = 0; j < CantidadCorredoresArray(corredores); j++)
                        {

                            if (posAux == pos[j])
                            {

                                posRepetida = true;

                                break;

                            }

                        }

                        if (!posRepetida)
                        {

                            pos[i] = posAux;

                        }


                    } while (posRepetida);

                }

            }

            return pos;
        }

        /// <summary>
        /// Nos devuelve la cantidad de corredores según el array de id de corredores
        /// </summary>
        /// <param name="corredores"></param>
        /// <returns></returns>
        public static int CantidadCorredoresArray(string[] corredores)
        {

            string idNulo = "-1";
            int corredoresNum = 0;



            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                if (corredores[i] != idNulo)
                {

                    corredoresNum++;

                }

            }

            return corredoresNum;

        }

        /// <summary>
        /// Printea el auto según el color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="auto"></param>
        /// <param name="numAuto"></param>
        public static void PrintearAutoColor(string color, string auto, string numAuto)
        {

            switch (color)
            {
                case "Rojo":

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Verde":

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Azul":

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Amarillo":

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Celeste":

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Rosa":

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Violeta":

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Gris":

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Naranja":

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                case "Bordo":

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{numAuto + " " + auto,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

            }

        }

        /// <summary>
        /// Ordena las posiciones de manera ascendente asociando el id de corredor correspondiente
        /// </summary>
        /// <param name="idPosUltimaCarrera"></param>
        /// <param name="posicionUltimaCarrera"></param>
        public static void OrdernarPosicionYIdAsc(string[] idPosUltimaCarrera, int[] posicionUltimaCarrera)
        {
            bool flag = true;



            for (int i = 0; i < posicionUltimaCarrera.Length && flag; i++)
            {

                flag = false;

                for (int j = 0; j < posicionUltimaCarrera.Length - i - 1; j++)
                {

                    if (posicionUltimaCarrera[j] > posicionUltimaCarrera[j + 1])
                    {

                        flag = true;

                        int auxPos = posicionUltimaCarrera[j];
                        string auxId = idPosUltimaCarrera[j];

                        posicionUltimaCarrera[j] = posicionUltimaCarrera[j + 1];
                        posicionUltimaCarrera[j + 1] = auxPos;

                        idPosUltimaCarrera[j] = idPosUltimaCarrera[j + 1];
                        idPosUltimaCarrera[j + 1] = auxId;

                    }

                }

            }

        }

        /// <summary>
        /// Ordena las posiciones de manera descendente asociando el id de corredor correspondiente
        /// </summary>
        /// <param name="idPosUltimaCarrera"></param>
        /// <param name="posicionUltimaCarrera"></param>
        public static void OrdernarPosicionYIdDesc(string[] idPosUltimaCarrera, int[] posicionUltimaCarrera)
        {
            bool flag = true;



            for (int i = 0; i < posicionUltimaCarrera.Length && flag; i++)
            {

                flag = false;

                for (int j = 0; j < posicionUltimaCarrera.Length - i - 1; j++)
                {

                    if (posicionUltimaCarrera[j] < posicionUltimaCarrera[j + 1])
                    {

                        flag = true;

                        int auxPos = posicionUltimaCarrera[j];
                        string auxId = idPosUltimaCarrera[j];

                        posicionUltimaCarrera[j] = posicionUltimaCarrera[j + 1];
                        posicionUltimaCarrera[j + 1] = auxPos;

                        idPosUltimaCarrera[j] = idPosUltimaCarrera[j + 1];
                        idPosUltimaCarrera[j + 1] = auxId;

                    }

                }

            }

        }

        /// <summary>
        /// Imprime el primer corredor con su auto
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="auto"></param>
        public static void ImprimirPrimero(string[,] corredores, int[,] carreras, string auto)
        {
            int puntajeMax = 0;
            int posC1 = 0;
            int posC2 = 0;
            int posC3 = 0;
            string id = "";
            string nombre = "";
            string marca = "";
            string color = "";
            string caracteristica = "";
            string fila = "";




            for (int i = 0; i < carreras.GetLength(0); i++)
            {

                if (i == 0)
                {

                    puntajeMax = carreras[i, 4];
                    id = carreras[i, 0].ToString();
                    posC1 = carreras[i, 1];
                    posC2 = carreras[i, 2];
                    posC3 = carreras[i, 3];

                }
                else if (puntajeMax < carreras[i, 4])
                {

                    puntajeMax = carreras[i, 4];
                    id = carreras[i, 0].ToString();
                    posC1 = carreras[i, 1];
                    posC2 = carreras[i, 2];
                    posC3 = carreras[i, 3];

                }

            }


            for (int i = 0; i < corredores.GetLength(0); i++)
            {
                if (id == corredores[i, 0])
                {

                    nombre = corredores[i, 1];
                    caracteristica = corredores[i, 2];
                    marca = corredores[i, 3];
                    color = corredores[i, 4];

                    break;

                }
            }


            fila = String.Format("|{0,-5}| {1,-5}| {2, -15}| {3,-15}| {4,-15}| {5,-15}| {6,-10}| {7,-10}| {8,-10}| {9,-10}| ",
                "Pos.", "id", "Nombre", "Carac.", "Marca", "Color", "Pos Car 1", "Pos Car 2", "Pos Car 3", "Puntaje");

            Console.WriteLine();
            Console.Write($"{"*******",15}");
            Console.Write($"{"",4}");

            PrintearAutoColor(color, auto, id);

            Console.Write($"{"*******",-15}");
            Console.WriteLine();


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            Menu.ArmarFilaCabecera(fila);

            Console.ForegroundColor = ConsoleColor.White;


            fila = String.Format("|{0,-5}| {1,-5}| {2, -15}| {3,-15}| {4,-15}| {5,-15}| {6,-10}| {7,-10}| {8,-10}| {9,-10}| ",
                "1°", id, nombre, caracteristica, marca, color, posC1, posC2, posC3, puntajeMax);

            Menu.ArmarFila(fila);


            Console.WriteLine();

        }



    }
}
