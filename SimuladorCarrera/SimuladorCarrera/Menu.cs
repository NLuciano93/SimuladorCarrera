using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorCarrera
{
    class Menu
    {


        /// <summary>
        /// Se encarga de armar el primer menu que se nos muestra
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="puntaje"></param>
        /// <param name="posicionUltimaCarrera"></param>
        /// <param name="idPosUltimaCarrera"></param>
        /// <param name="auto"></param>
        /// <param name="numCarrera"></param>
        public static void Principal(string[,] corredores, int[,] carreras, int[] puntaje, int[] posicionUltimaCarrera, string[] idPosUltimaCarrera, string auto, ref int numCarrera)
        {

            bool salir = false;
            string[] menuPrincipal = { "Mostrar Corredores", "Buscar Corredor", "Agregar Corredor", "Modificar Corredor", "Eliminar Corredor", "Carrera", "Salir" };
            string[] menuMostrar = { "Mostrar todos", "Mostrar por Característica", "Mostrar por Marca", "Ordenar por Posición Ult. Temp", "Volver" };
            string[] menuBuscar = { "Por Nombre", "Por ID", "Volver" };
            string[] menuCarrera = { "Nueva Temporada", "Carrera", "Volver" };


            do
            {

                Console.Clear();

                Console.WriteLine("Bienvenido a la competición de carreras más importante del mundo!!");

                Menu.ArmarMenu("Este es el menú de opciones: ", menuPrincipal);


                switch (Validaciones.ValidarOpcionMenu("Elija una opción: ", menuPrincipal.Length))
                {

                    case 1:

                        Corredores.MostrarCorredores(menuMostrar, corredores, carreras);

                        break;

                    case 2:

                        Corredores.BuscarCorredor(menuBuscar, corredores, carreras);

                        break;

                    case 3:

                        Corredores.AgregarCorredor(corredores, carreras, idPosUltimaCarrera, posicionUltimaCarrera);

                        break;

                    case 4:

                        Corredores.ModificarCorredor(corredores, carreras, idPosUltimaCarrera);

                        break;

                    case 5:


                        Corredores.EliminarCorredor(corredores, carreras, idPosUltimaCarrera, posicionUltimaCarrera);

                        break;

                    case 6:

                        Carrera.MenuCarrera(menuCarrera, corredores, carreras, idPosUltimaCarrera, posicionUltimaCarrera, auto, ref numCarrera, puntaje);

                        break;

                    case 7:

                        if (Validaciones.BooleanaYN("Está seguro que desea salir? "))
                        {
                            salir = true;
                        }

                        break;

                }


            } while (!salir);


        }

        /// <summary>
        /// Permite armar los menú de las diferentes opciones
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="menu"></param>
        public static void ArmarMenu(string mensaje, string[] menu)
        {

            Console.WriteLine();
            Console.WriteLine($"{mensaje}");
            Console.WriteLine();

            for (int i = 0; i < menu.Length; i++)
            {

                Console.WriteLine($"{i + 1}- {menu[i]} ");

            }

        }

        /// <summary>
        /// Se encarga de armar el encabezado de una tabla
        /// </summary>
        /// <param name="filaCabecera"></param>
        public static void ArmarFilaCabecera(string filaCabecera)
        {

            string divisor = "-";


            for (int i = 0; i < filaCabecera.Length; i++)
            {

                Console.Write(divisor);

            }

            Console.WriteLine();

            Console.WriteLine(filaCabecera);

            for (int i = 0; i < filaCabecera.Length; i++)
            {

                Console.Write(divisor);

            }

            Console.WriteLine();

        }

        /// <summary>
        /// Se encarga de armar filas del cuerpo de la tabla
        /// </summary>
        /// <param name="fila"></param>
        public static void ArmarFila(string fila)
        {

            string divisor = "-";


            Console.WriteLine(fila);

            for (int i = 0; i < fila.Length; i++)
            {

                Console.Write(divisor);

            }

            Console.WriteLine();

        }


        /// <summary>
        /// Devuelve los colores disponibles para seleccionar
        /// </summary>
        /// <param name="indice"></param>
        /// <param name="corredores"></param>
        /// <returns></returns>
        public static string ColoresDisponibles(ref int indice, string[,] corredores)
        {

            string[] arrayColores = new string[corredores.GetLength(0)];
            bool colorNoDisponible = false;
            string[] coloresDisponible = new string[Enum.GetNames(typeof(Program.Color)).Length];
            int k = 0;


            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                if (corredores[i, 4] != "EspacioDisponible")
                {

                    arrayColores[i] = corredores[i, 4];

                }

            }


            foreach (var item in Enum.GetValues(typeof(Program.Color)))
            {

                colorNoDisponible = false;


                for (int j = 0; j < arrayColores.Length; j++)
                {

                    if (arrayColores != null)
                    {

                        if (arrayColores[j] == item.ToString())
                        {

                            colorNoDisponible = true;

                            break;

                        }

                    }

                }


                if (!colorNoDisponible)
                {

                    Console.WriteLine($"{++indice}- {item}");
                    coloresDisponible[k++] = item.ToString();

                }

            }

            return coloresDisponible[Validaciones.ValidarOpcionMenu("Elije el numero del color : ", indice) - 1];


        }


    }
}
