using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimuladorCarrera
{
    class Carrera
    {

        /// <summary>
        /// Se encarga de mostrar las opciones de carrera como Nueva temporada y carrera
        /// </summary>
        /// <param name="menuCarrera"></param>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="idPosUltimaCarrera"></param>
        /// <param name="posicionUltimaCarrera"></param>
        /// <param name="auto"></param>
        /// <param name="numCarrera"></param>
        /// <param name="puntaje"></param>
        public static void MenuCarrera(string[] menuCarrera, string[,] corredores, int[,] carreras, string[] idPosUltimaCarrera, int[] posicionUltimaCarrera, string auto, ref int numCarrera, int[] puntaje)
        {

            bool salir = false;


            do
            {

                Console.Clear();
                Console.WriteLine();

                Menu.ArmarMenu("Estás son las opciones: ", menuCarrera);

                switch (Validaciones.ValidarOpcionMenu("Elija la opción que desea: ", menuCarrera.Length))
                {
                    case 1:

                        NuevaTemporada(corredores, carreras, idPosUltimaCarrera, posicionUltimaCarrera, auto, ref numCarrera);

                        break;

                    case 2:

                        Competencia(corredores, carreras, idPosUltimaCarrera, posicionUltimaCarrera, auto, ref numCarrera, puntaje);

                        break;

                    case 3:

                        salir = true;

                        break;
                }


            } while (!salir);


        }


        /// <summary>
        /// Si se corrieron todas las carreras de la temporada muestra al primero y reinicia las posiciones de la matriz de carreras
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="idPosUltimaCarrera"></param>
        /// <param name="posicionUltimaCarrera"></param>
        /// <param name="auto"></param>
        /// <param name="numCarrera"></param>
        public static void NuevaTemporada(string[,] corredores, int[,] carreras, string[] idPosUltimaCarrera, int[] posicionUltimaCarrera, string auto, ref int numCarrera)
        {

            bool nuevaTemporada = false;


            Console.Clear();


            if (numCarrera == 4)
            {

                Console.WriteLine();
                Console.WriteLine("El campeón de esta temporada es: ");

                Helper.ImprimirPrimero(corredores, carreras, auto);

                nuevaTemporada = true;


                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();

            }
            else
            {

                Console.WriteLine();

                Console.WriteLine($"Todavía no finalizó, la temporada faltan {4 - numCarrera} carrera/s");

                Console.WriteLine();

                if (Validaciones.BooleanaYN("Desea iniciar una nueva temporada? "))
                {

                    nuevaTemporada = true;

                }
                else
                {

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Vuelva al menú y elija correr la siguiente carrera");
                }

            }


            if (nuevaTemporada)
            {

                for (int i = 0; i < carreras.GetLength(0); i++)
                {

                    for (int j = 1; j < carreras.GetLength(1); j++)
                    {

                        if (carreras[i, 0] != -1)
                        {

                            carreras[i, j] = 0;

                        }

                    }

                    if (posicionUltimaCarrera[i] != -1)
                    {

                        posicionUltimaCarrera[i] = 0;

                    }

                }

                numCarrera = 1;

                Console.Clear();

                if (Validaciones.BooleanaYN("Quiere ver como queda la tabla desde cero? "))
                {

                    Corredores.Mostrar(corredores, carreras);

                }
                else
                {

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para volver");
                    Console.ReadKey();
                }


            }


        }


        /// <summary>
        /// Se detecta el número de carrera que se debe correr y se juega esa carrera.
        /// Consiste en 5 vueltas, se generan posiciones aleatorias y que no se repiten, luego de la última vuelta se graban las posiciones
        /// en el array de carreras y se calcula el puntaje
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="idPosUltimaCarrera"></param>
        /// <param name="posicionUltimaCarrera"></param>
        /// <param name="auto"></param>
        /// <param name="numCarrera"></param>
        /// <param name="puntaje"></param>
        public static void Competencia(string[,] corredores, int[,] carreras, string[] idPosUltimaCarrera, int[] posicionUltimaCarrera, string auto, ref int numCarrera, int[] puntaje)
        {


            Console.Clear();
            Console.WriteLine();


            if (numCarrera == 4)
            {

                Console.WriteLine("Finalizamos todas las competencias de la temporada");

                Console.WriteLine();
                Console.WriteLine("El corredor campeón es: ");

                Helper.ImprimirPrimero(corredores, carreras, auto);

                if (Validaciones.BooleanaYN("Desea comenzar una nueva temporada? "))
                {

                    Carrera.NuevaTemporada(corredores, carreras, idPosUltimaCarrera, posicionUltimaCarrera, auto, ref numCarrera);

                }

            }
            else
            {

                Console.WriteLine($"Estamos en la carrera {numCarrera}");

                if (Validaciones.BooleanaYN("Procedemos a correrla? "))
                {


                    for (int vuelta = 0; vuelta < 6; vuelta++)
                    {

                        Console.Clear();
                        if (vuelta == 0)
                        {

                            Console.WriteLine("----------------------");
                            Console.WriteLine("Largan:");
                            Console.WriteLine("----------------------");

                        }
                        else if (vuelta < 5)
                        {

                            Console.WriteLine("----------------------");
                            Console.WriteLine($"Vuelta: {vuelta}/5");
                            Console.WriteLine("----------------------");

                        }
                        else
                        {

                            Console.WriteLine("----------------------");
                            Console.WriteLine("Final:");
                            Console.WriteLine("----------------------");

                        }

                        Helper.OrdernarPosicionYIdAsc(idPosUltimaCarrera, posicionUltimaCarrera);


                        for (int i = 0; i < posicionUltimaCarrera.Length; i++)
                        {

                            if (posicionUltimaCarrera[i] != -1)
                            {

                                for (int j = 0; j < corredores.GetLength(0); j++)
                                {

                                    if (idPosUltimaCarrera[i] == corredores[j, 0])
                                    {

                                        Thread.Sleep(1000 * (i / 2));


                                        Console.Write($"|{posicionUltimaCarrera[i] + "°",-5 }");
                                        Helper.PrintearAutoColor(corredores[j, 4], auto, idPosUltimaCarrera[i]);
                                        Console.WriteLine("|");
                                        Console.WriteLine("----------------------");


                                        break;

                                    }

                                }

                            }

                        }

                        Helper.OrdernarPosicionYIdDesc(idPosUltimaCarrera, posicionUltimaCarrera);

                        if (vuelta < 5)
                        {

                            posicionUltimaCarrera = Helper.PosRandomParaVueltaCarrera(posicionUltimaCarrera, idPosUltimaCarrera);

                        }

                        if (vuelta < 5)
                        {

                            Thread.Sleep(5000);

                        }
                        else
                        {

                            Console.WriteLine();
                            Console.WriteLine("Finalizó la carrera");
                            Console.WriteLine();

                        }

                    }


                    for (int i = 0; i < posicionUltimaCarrera.Length; i++)
                    {

                        if (posicionUltimaCarrera[i] != -1)
                        {

                            for (int j = 0; j < carreras.GetLength(0); j++)
                            {

                                if (Convert.ToInt32(idPosUltimaCarrera[i]) == carreras[j, 0])
                                {

                                    carreras[j, numCarrera] = posicionUltimaCarrera[i];

                                    break;

                                }

                            }

                        }

                    }

                    for (int i = 0; i < carreras.GetLength(0); i++)
                    {

                        if (carreras[i, 0] != -1)
                        {

                            carreras[i, 4] = 0;

                            for (int j = 1; j < carreras.GetLength(1) - 1; j++)
                            {

                                if (carreras[i, j] > 0)
                                {

                                    carreras[i, 4] += puntaje[carreras[i, j] - 1];

                                }

                            }

                        }

                    }

                    numCarrera++;

                    if (Validaciones.BooleanaYN("Quiere ver la tabla de corredores, por posición? "))
                    {

                        Corredores.OrdenarCarreraPuntaje(corredores, carreras);

                    }
                }

                Console.ReadKey();

            }

        }


    }
}
