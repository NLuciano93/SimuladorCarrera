using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorCarrera
{
    class Validaciones
    {
        /// <summary>
        /// Validador de opciones de menú, devuelve la opción elegida mientras sea correcta, se toma como default la mínima opción igual a 1
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static int ValidarOpcionMenu(string mensaje, int max, int min = 1)
        {

            int opt = 0;


            Console.WriteLine();
            Console.Write(mensaje);

            while (!int.TryParse(Console.ReadLine(), out opt) || opt < min || opt > max)
            {

                Console.WriteLine();
                Console.Write("Error en la opción elegida, ingrese nuevamente una opción correcta: ");

            }

            return opt;

        }

        /// <summary>
        /// Validador del (y/n) devuelve false si se elige n o true si se elige y
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static bool BooleanaYN(string mensaje)
        {

            string key = "";


            Console.WriteLine();
            Console.Write($"{mensaje} (y/n): ");

            key = Console.ReadLine().ToLower();

            while (key != "y" && key != "n")
            {

                Console.WriteLine();
                Console.Write("Ingresó una tecla incorrecta, por favor ingrese y o n: ");
                key = Console.ReadLine().ToLower();

            }

            return (key == "y");
        }

        /// <summary>
        /// Valida y devuelve true o false si la cadena pasada no contiene números
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsAllLettersOrWhiteSpace(string s)
        {

            foreach (char letra in s)
            {

                if (!Char.IsLetter(letra) && !Char.IsWhiteSpace(letra))
                    return false;

            }

            return true;

        }

        /// <summary>
        /// Valida y devuelve true o false si la cadena pasada solamente contiene números
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsAllDigits(string s)
        {

            foreach (char c in s)
            {

                if (!Char.IsDigit(c))
                    return false;

            }

            return true;

        }


        /// <summary>
        /// Valida que no haya id Repetidos en la matriz de corredores, devolviendo true o false
        /// </summary>
        /// <param name="id"></param>
        /// <param name="corredores"></param>
        /// <returns></returns>
        public static bool IdRepetido(string id, string[,] corredores)
        {

            bool idRepetido = false;


            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                if (corredores[i, 0] == id)
                {

                    idRepetido = true;
                    break;

                }

            }

            return idRepetido;

        }


    }
}
