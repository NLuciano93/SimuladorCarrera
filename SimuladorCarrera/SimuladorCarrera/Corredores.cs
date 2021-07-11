using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorCarrera
{
    class Corredores
    {

        /// <summary>
        /// Se encarga de mostrar las diferentes opciones para visualizar a los corredores
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        public static void MostrarCorredores(string[] menu, string[,] corredores, int[,] carreras)
        {

            bool salir = false;


            do
            {

                Console.Clear();
                Console.WriteLine();

                Menu.ArmarMenu("Estás son las opciones: ", menu);

                switch (Validaciones.ValidarOpcionMenu("Elija la opción que desea: ", menu.Length))
                {
                    case 1:

                        Mostrar(corredores, carreras);

                        break;

                    case 2:

                        MostrarPorCarac(corredores, carreras);

                        break;

                    case 3:

                        MostrarPorMarca(corredores, carreras);

                        break;

                    case 4:

                        OrdenarCarreraPuntaje(corredores, carreras);

                        break;

                    case 5:

                        salir = true;

                        break;

                }


            } while (!salir);


        }

        /// <summary>
        /// Se encarga de mostrar la tabla asociando la matriz de corredores y la matriz de carreras
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        public static void Mostrar(string[,] corredores, int[,] carreras)
        {

            string fila = "";
            int largoFila = 0;
            string divisor = "-";
            int contador = 0;
            bool encontrado = false;


            Console.Clear();
            Console.WriteLine();

            fila = String.Format("|{0,-5}| {1, -15}| {2,-15}| {3,-15}| {4,-15}| {5,-10}| {6,-10}| {7,-10}| {8,-10}| ",
                "id", "Nombre", "Carac.", "Marca", "Color", "Pos Car 1", "Pos Car 2", "Pos Car 3", "Puntaje");


            Console.ForegroundColor = ConsoleColor.Green;

            Menu.ArmarFilaCabecera(fila);

            Console.ForegroundColor = ConsoleColor.White;


            for (int i = 0; i < carreras.GetLength(0); i++)
            {

                if (carreras[i, 0] != -1)
                {

                    encontrado = false;


                    for (int j = 0; j < corredores.GetLength(0); j++)
                    {

                        for (int k = 0; k < corredores.GetLength(1); k++)
                        {

                            if (Convert.ToInt32(corredores[j, 0]) == carreras[i, 0])
                            {

                                if (k == 0)
                                {
                                    Console.Write($"|{corredores[j, k],-5} |");

                                    largoFila += 8;

                                    encontrado = true;

                                }
                                else
                                {
                                    Console.Write($"{corredores[j, k],-15}| ");

                                    largoFila += 17;
                                }


                            }

                        }

                        if (encontrado)
                        {
                            break;
                        }


                    }


                    for (int j = 1; j < carreras.GetLength(1); j++)
                    {

                        if (carreras[i, j] != 0)
                        {

                            Console.Write($"{carreras[i, j],-10}| ");

                            largoFila += 12;
                        }
                        else
                        {
                            Console.Write($"{"N/C",-10}| ");

                            largoFila += 12;
                        }


                    }

                    Console.WriteLine();

                    for (int j = 0; j < largoFila; j++)
                    {

                        Console.Write(divisor);

                    }

                    Console.WriteLine();

                    largoFila = 0;

                    contador++;


                }

            }

            if (contador == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No hay corredores");
            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

        }

        /// <summary>
        /// Filtra y muestra corredores según caracteristica
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        public static void MostrarPorCarac(string[,] corredores, int[,] carreras)
        {

            string[,] corredoresAux = new string[corredores.GetLength(0), corredores.GetLength(1)];
            int[,] carrerasAux = new int[carreras.GetLength(0), carreras.GetLength(1)];
            string[] caracteristicas = new string[Enum.GetNames(typeof(Program.Caracteristica)).Length];
            caracteristicas = Enum.GetNames(typeof(Program.Caracteristica));
            int optCarac = 0;



            Console.Clear();
            Console.WriteLine();

            Menu.ArmarMenu("Estás son las opciones: ", caracteristicas);

            optCarac = Validaciones.ValidarOpcionMenu("Elija por cual característica buscar: ", caracteristicas.Length);


            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                if (corredores[i, 2] == Enum.GetName(typeof(Program.Caracteristica), optCarac))
                {

                    for (int j = 0; j < corredores.GetLength(1); j++)
                    {

                        corredoresAux[i, j] = corredores[i, j];

                    }


                    for (int f = 0; f < carreras.GetLength(0); f++)
                    {
                        if (carreras[f, 0] == Convert.ToInt32(corredoresAux[i, 0]))
                        {
                            for (int j = 0; j < carreras.GetLength(1); j++)
                            {

                                carrerasAux[i, j] = carreras[f, j];

                            }
                        }

                    }


                }
                else
                {

                    corredoresAux[i, 0] = "-1";
                    carrerasAux[i, 0] = -1;

                }

            }


            Mostrar(corredoresAux, carrerasAux);

        }

        /// <summary>
        /// Filtra y muestra corredores según la marca de auto que manejan
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        public static void MostrarPorMarca(string[,] corredores, int[,] carreras)
        {

            string[,] corredoresAux = new string[corredores.GetLength(0), corredores.GetLength(1)];
            int[,] carrerasAux = new int[carreras.GetLength(0), carreras.GetLength(1)];
            string[] marcas = new string[Enum.GetNames(typeof(Program.Marcas)).Length];
            marcas = Enum.GetNames(typeof(Program.Marcas));
            int optMarca = 0;



            Console.Clear();
            Console.WriteLine();

            Menu.ArmarMenu("Estás son las opciones: ", marcas);

            optMarca = Validaciones.ValidarOpcionMenu("Elija por cual marca buscar: ", marcas.Length);


            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                if (corredores[i, 3] == Enum.GetName(typeof(Program.Marcas), optMarca))
                {

                    for (int j = 0; j < corredores.GetLength(1); j++)
                    {

                        corredoresAux[i, j] = corredores[i, j];

                    }

                    for (int f = 0; f < carreras.GetLength(0); f++)
                    {
                        if (carreras[f, 0] == Convert.ToInt32(corredoresAux[i, 0]))
                        {
                            for (int j = 0; j < carreras.GetLength(1); j++)
                            {

                                carrerasAux[i, j] = carreras[f, j];

                            }
                        }

                    }

                }
                else
                {

                    corredoresAux[i, 0] = "-1";
                    carrerasAux[i, 0] = -1;

                }

            }


            Mostrar(corredoresAux, carrerasAux);
        }


        /// <summary>
        /// Se encarga de mostrar las diferentes opciones para visualizar la búsqueda de algún corredor según nombre o id
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        public static void BuscarCorredor(string[] menu, string[,] corredores, int[,] carreras)
        {

            bool salir = false;


            do
            {

                Console.Clear();

                Menu.ArmarMenu("Estas son las opciones:", menu);

                switch (Validaciones.ValidarOpcionMenu("Elija opción: ", menu.Length))
                {
                    case 1:

                        BusquedaPorNombre(corredores, carreras);

                        break;

                    case 2:

                        BusquedaPorId(corredores, carreras);

                        break;

                    case 3:

                        salir = true;

                        break;

                    default:
                        break;

                }


            } while (!salir);


        }

        /// <summary>
        /// Filtra y muestra el corredor buscado por nombre, si no lo encuentra se informa también
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        public static void BusquedaPorNombre(string[,] corredores, int[,] carreras)
        {

            string nombre = "";
            string fila = "";
            string divisor = "-";
            int contadorOcur = 0;
            int largoFila = 0;
            int idMatch = -2;
            bool encontrado = false;


            Console.Clear();
            Console.Write("Ingrese el nombre del corredor que desea buscar: ");

            nombre = Console.ReadLine();

            while (nombre.Length < 2 || !Validaciones.IsAllLettersOrWhiteSpace(nombre))
            {

                Console.WriteLine();
                Console.WriteLine("El nombre ingresado no es válido, ingreselo nuevamente: ");
                nombre = Console.ReadLine();

            }

            Console.Clear();

            Console.WriteLine("El resultado de la búsqueda es:");
            Console.WriteLine();


            fila = String.Format("|{0,-5}| {1, -15}| {2,-15}| {3,-15}| {4,-15}| {5,-10}| {6,-10}| {7,-10}| {8,-10}| ",
                                             "id", "Nombre", "Carac.", "Marca", "Color", "Pos Car 1", "Pos Car 2", "Pos Car 3", "Puntaje");


            Console.ForegroundColor = ConsoleColor.Green;

            Menu.ArmarFilaCabecera(fila);

            Console.ForegroundColor = ConsoleColor.White;


            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                if (corredores[i, 1].ToLower() == nombre.ToLower().Trim())
                {

                    for (int j = 0; j < corredores.GetLength(1); j++)
                    {

                        if (j == 0)
                        {

                            idMatch = Convert.ToInt32(corredores[i, j]);
                            Console.Write($"|{corredores[i, j],-5} |");

                            largoFila += 8;

                        }
                        else
                        {

                            Console.Write($"{corredores[i, j],-15}| ");

                            largoFila += 17;

                        }

                    }

                    for (int j = 0; j < carreras.GetLength(0); j++)
                    {

                        for (int k = 1; k < carreras.GetLength(1); k++)
                        {

                            if (Convert.ToInt32(corredores[j, 0]) == idMatch)
                            {

                                encontrado = true;

                                if (carreras[j, k] != 0)
                                {

                                    Console.Write($"{carreras[j, k],-10}| ");

                                    largoFila += 12;

                                }
                                else
                                {
                                    Console.Write($"{"N/C",-10}| ");

                                    largoFila += 12;

                                }
                            }

                        }

                        if (encontrado)
                        {
                            break;
                        }
                    }

                    Console.WriteLine();

                    for (int j = 0; j < largoFila; j++)
                    {

                        Console.Write(divisor);

                    }

                    Console.WriteLine();

                    largoFila = 0;

                    contadorOcur++;

                }

            }


            if (contadorOcur == 0)
            {

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"El corredor buscado por el nombre \"{nombre}\" no existe en el sistema.");

            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para volver");
            Console.ReadKey();

        }

        /// <summary>
        ///  Filtra y muestra el corredor buscado por id, si no lo encuentra se informa también
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="id"></param>
        public static void BusquedaPorId(string[,] corredores, int[,] carreras, string id = "-1")
        {

            string fila = "";
            string divisor = "-";
            int contadorOcur = 0;
            int largoFila = 0;
            bool encontrado = false;


            if (id == "-1")
            {

                Console.Clear();
                Console.Write("Ingrese el id del corredor que desea buscar: ");

                id = Console.ReadLine();

                while (id.Length == 0 || !Validaciones.IsAllDigits(id))
                {

                    Console.WriteLine();
                    Console.WriteLine("El id ingresado no es válido, ingreselo nuevamente: ");
                    id = Console.ReadLine();

                }

                Console.Clear();

                Console.WriteLine("El resultado de la búsqueda es:");
                Console.WriteLine();

            }


            fila = String.Format("|{0,-5}| {1, -15}| {2,-15}| {3,-15}| {4,-15}| {5,-10}| {6,-10}| {7,-10}| {8,-10}| ",
                                             "id", "Nombre", "Carac.", "Marca", "Color", "Pos Car 1", "Pos Car 2", "Pos Car 3", "Puntaje");

            Console.ForegroundColor = ConsoleColor.Green;
            Menu.ArmarFilaCabecera(fila);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                encontrado = false;


                if (corredores[i, 0].ToLower() == id.ToLower().Trim())
                {

                    for (int j = 0; j < corredores.GetLength(1); j++)
                    {

                        if (j == 0)
                        {

                            Console.Write($"|{corredores[i, j],-5} |");

                            largoFila += 8;

                        }
                        else
                        {

                            Console.Write($"{corredores[i, j],-15}| ");

                            largoFila += 17;

                        }


                    }

                    for (int j = 0; j < carreras.GetLength(0); j++)
                    {

                        for (int k = 1; k < carreras.GetLength(1); k++)
                        {

                            if (carreras[j, 0] == Convert.ToInt32(id.ToLower().Trim()))
                            {

                                encontrado = true;

                                if (carreras[j, k] != 0)
                                {

                                    Console.Write($"{carreras[j, k],-10}| ");

                                    largoFila += 12;

                                }
                                else
                                {

                                    Console.Write($"{"N/C",-10}| ");

                                    largoFila += 12;

                                }

                            }

                        }

                        if (encontrado)
                        {
                            break;
                        }

                    }

                    Console.WriteLine();

                    for (int j = 0; j < largoFila; j++)
                    {

                        Console.Write(divisor);

                    }

                    Console.WriteLine();

                    largoFila = 0;

                    contadorOcur++;

                }


            }


            if (contadorOcur == 0)
            {

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"El corredor buscado por el id \"{id}\" no existe en el sistema.");

            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

        }

        /// <summary>
        /// Alta de un corredor si hay espacio disponible
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="idPosUltimaCarrera"></param>
        /// <param name="posUltimaCarrera"></param>
        public static void AgregarCorredor(string[,] corredores, int[,] carreras, string[] idPosUltimaCarrera, int[] posUltimaCarrera)
        {

            string id = "";
            string nombre = "";
            string carac = "";
            string marca = "";
            string color = "";
            bool hayLugar = false;
            int lugar = 0;
            int indice = 0;



            Console.Clear();
            Console.WriteLine();


            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                if (corredores[i, 0] == "-1")
                {

                    hayLugar = true;
                    lugar = i;

                    break;

                }

            }

            if (hayLugar)
            {

                Console.WriteLine("A continuación ingresará los datos del corredor");

                Console.WriteLine();
                Console.Write("Ingrese el id del corredor: ");

                id = Console.ReadLine();

                while (id.Length == 0 || !Validaciones.IsAllDigits(id))
                {

                    Console.WriteLine();
                    Console.Write("El id ingresado no es válido, ingrese nuevamente: ");
                    id = Console.ReadLine();

                }

                while (Validaciones.IdRepetido(id, corredores))
                {

                    Console.WriteLine();
                    Console.Write("El id ingresado ya existe, ingrese otro nuevamente: ");
                    id = Console.ReadLine();


                    while (id.Length == 0 || !Validaciones.IsAllDigits(id))
                    {

                        Console.WriteLine();
                        Console.Write("El id ingresado no es válido, ingrese nuevamente: ");
                        id = Console.ReadLine();

                    }

                }


                Console.Clear();

                Console.WriteLine();
                Console.Write("Ingrese Nombre: ");
                nombre = Console.ReadLine();

                while (nombre.Length < 2 || !Validaciones.IsAllLettersOrWhiteSpace(nombre))
                {

                    Console.WriteLine();
                    Console.Write("Nombre ingresado incorrecto por favor ingrese nuevamente: ");
                    nombre = Console.ReadLine();

                }

                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("Estas son las opciones de características");

                foreach (var item in Enum.GetValues(typeof(Program.Caracteristica)))
                {

                    Console.WriteLine($"{++indice}- {item}");

                }

                carac = Enum.GetName(typeof(Program.Caracteristica), Validaciones.ValidarOpcionMenu("Elije el numero de una caracteristica: ", indice));


                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("Estas son las opciones de marca de auto");
                indice = 0;

                foreach (var item in Enum.GetValues(typeof(Program.Marcas)))
                {

                    Console.WriteLine($"{++indice}- {item}");

                }

                marca = Enum.GetName(typeof(Program.Marcas), Validaciones.ValidarOpcionMenu("Elije el numero de una caracteristica: ", indice));

                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("Estas son las opciones de colores para el auto");
                indice = 0;

                color = Menu.ColoresDisponibles(ref indice, corredores);


                Console.Clear();
                Console.WriteLine();

                Console.WriteLine("Estos son los datos a ingresar:");
                Console.WriteLine($"Id: {id}");
                Console.WriteLine($"Nombre: {nombre}");
                Console.WriteLine($"Característica: {carac}");
                Console.WriteLine($"Marca: {marca}");
                Console.WriteLine($"Color: {color}");

                if (Validaciones.BooleanaYN("Quiere agregar estos datos?"))
                {

                    corredores[lugar, 0] = id;
                    corredores[lugar, 1] = nombre;
                    corredores[lugar, 2] = carac;
                    corredores[lugar, 3] = marca;
                    corredores[lugar, 4] = color;

                    for (int i = 0; i < carreras.GetLength(0); i++)
                    {

                        if (carreras[i, 0] == -1)
                        {

                            carreras[i, 0] = Convert.ToInt32(id);
                            carreras[i, 1] = 0;
                            carreras[i, 2] = 0;
                            carreras[i, 3] = 0;
                            carreras[i, 4] = 0;

                            break;

                        }

                    }

                    for (int i = 0; i < idPosUltimaCarrera.Length; i++)
                    {

                        if (idPosUltimaCarrera[i] == "-1")
                        {

                            idPosUltimaCarrera[i] = id;
                            posUltimaCarrera[i] = 0;

                            break;

                        }

                    }

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"Corredor {nombre} agregado correctamente");

                }
                else
                {

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Corredor no agregado");

                }

            }
            else
            {

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("No hay lugar para un corredor nuevo");

            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para volver");
            Console.ReadKey();


        }

        /// <summary>
        /// Se muestran corredores y se elije por id cual es corredor al que se necesita hacerles modificaciones
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="idPosUltimaCarrera"></param>
        public static void ModificarCorredor(string[,] corredores, int[,] carreras, string[] idPosUltimaCarrera)
        {


            string id = "";
            string idViejo = "";
            string nombre = "";
            string carac = "";
            string marca = "";
            string color = "";
            int lugar = 0;
            int indice = 0;


            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Estos son los corredores: ");

            Mostrar(corredores, carreras);

            Console.WriteLine();
            Console.Write("Escriba el id del corredor que desea modificar: ");

            id = Console.ReadLine();

            while (id.Length < 1 || !Validaciones.IsAllDigits(id) || !Validaciones.IdRepetido(id, corredores))
            {

                Console.WriteLine();
                Console.Write("El id indicado no es correcto o no pertenece a un corredor ingrese nuevamente: ");
                id = Console.ReadLine();

            }

            Console.Clear();

            Console.WriteLine();

            BusquedaPorId(corredores, carreras, id);

            if (Validaciones.BooleanaYN("Este es el corredor que desea modificar? "))
            {

                for (int i = 0; i < corredores.GetLength(0); i++)
                {

                    int j = 0;


                    if (id == corredores[i, j])
                    {

                        nombre = corredores[i, ++j];
                        carac = corredores[i, ++j];
                        marca = corredores[i, ++j];
                        color = corredores[i, ++j];
                        lugar = i;
                        idViejo = id;

                        break;

                    }

                }

                Console.Clear();
                Console.WriteLine();

                if (Validaciones.BooleanaYN($"Este es el id \"{id}\" desea modificarlo? "))
                {

                    Console.WriteLine();
                    Console.Write("Escriba el nuevo id del corredor: ");

                    id = Console.ReadLine();

                    while (id.Length < 1 || !Validaciones.IsAllDigits(id) || Validaciones.IdRepetido(id, corredores))
                    {

                        Console.WriteLine();
                        Console.Write("El id indicado no es correcto o pertenece a un corredor existente ingrese nuevamente: ");
                        id = Console.ReadLine();

                    }

                }

                Console.Clear();

                if (Validaciones.BooleanaYN($"Este es el nombre \"{nombre}\" desea modificarlo? "))
                {

                    Console.WriteLine();
                    Console.Write("Escriba el nuevo nombre del corredor: ");

                    nombre = Console.ReadLine();

                    while (nombre.Length < 2 || !Validaciones.IsAllLettersOrWhiteSpace(nombre))
                    {

                        Console.WriteLine();
                        Console.Write("Nombre ingresado incorrecto por favor ingrese nuevamente: ");
                        nombre = Console.ReadLine();

                    }

                }

                Console.Clear();

                if (Validaciones.BooleanaYN($"Este es la característica \"{carac}\" desea modificarla? "))
                {

                    Console.WriteLine();
                    Console.WriteLine("Estas son las opciones de características");

                    foreach (var item in Enum.GetValues(typeof(Program.Caracteristica)))
                    {

                        Console.WriteLine($"{++indice}- {item}");

                    }

                    carac = Enum.GetName(typeof(Program.Caracteristica), Validaciones.ValidarOpcionMenu("Elije el número de una caracteristica: ", indice));

                    indice = 0;

                }

                Console.Clear();

                if (Validaciones.BooleanaYN($"Este es la marca \"{marca}\" desea modificarla? "))
                {

                    Console.WriteLine();
                    Console.WriteLine("Estas son las opciones de marcas");

                    foreach (var item in Enum.GetValues(typeof(Program.Marcas)))
                    {

                        Console.WriteLine($"{++indice}- {item}");

                    }

                    marca = Enum.GetName(typeof(Program.Marcas), Validaciones.ValidarOpcionMenu("Elije el número de una marca: ", indice));

                    indice = 0;

                }

                Console.Clear();

                if (Validaciones.BooleanaYN($"Este es el \"{color}\" desea modificarlo? "))
                {

                    Console.WriteLine();
                    Console.WriteLine("Estas son las opciones de colores para el auto");


                    color = Menu.ColoresDisponibles(ref indice, corredores);

                    indice = 0;

                }

                Console.Clear();
                Console.WriteLine();

                Console.WriteLine("Estos son los datos actualizados:");
                Console.WriteLine($"Id: {id}");
                Console.WriteLine($"Nombre: {nombre}");
                Console.WriteLine($"Característica: {carac}");
                Console.WriteLine($"Marca: {marca}");
                Console.WriteLine($"Color: {color}");



                if (Validaciones.BooleanaYN("Quiere agregar estos datos?"))
                {


                    corredores[lugar, 0] = id;
                    corredores[lugar, 1] = nombre;
                    corredores[lugar, 2] = carac;
                    corredores[lugar, 3] = marca;
                    corredores[lugar, 4] = color;


                    for (int i = 0; i < carreras.GetLength(0); i++)
                    {

                        if (carreras[i, 0] == Convert.ToInt32(idViejo))
                        {

                            carreras[i, 0] = Convert.ToInt32(id);

                            break;

                        }

                    }

                    for (int i = 0; i < idPosUltimaCarrera.Length; i++)
                    {

                        if (idPosUltimaCarrera[i] == idViejo)
                        {

                            idPosUltimaCarrera[i] = id;

                            break;

                        }

                    }

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"Corredor {nombre} actualizado correctamente");

                }
                else
                {

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Corredor no actualizado");

                }


            }


            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

        }

        /// <summary>
        ///  Se muestran corredores y se elije por id cual es corredor al que se necesita eliminar de la matriz de corredores
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        /// <param name="idPosUltimaCarrera"></param>
        /// <param name="posUltimaCarrera"></param>
        public static void EliminarCorredor(string[,] corredores, int[,] carreras, string[] idPosUltimaCarrera, int[] posUltimaCarrera)
        {

            string id = "";


            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Estos son los corredores: ");

            Mostrar(corredores, carreras);

            Console.WriteLine();
            Console.Write("Escriba el id del corredor que desea eliminar: ");

            id = Console.ReadLine();

            while (id.Length < 1 || !Validaciones.IsAllDigits(id) || !Validaciones.IdRepetido(id, corredores))
            {

                Console.WriteLine();
                Console.Write("El id indicado no es correcto o no pertenece a un corredor ingrese nuevamente: ");
                id = Console.ReadLine();

            }

            Console.Clear();

            Console.WriteLine();

            BusquedaPorId(corredores, carreras, id);

            if (Validaciones.BooleanaYN("Este es el corredor que desea eliminar? "))
            {

                for (int i = 0; i < corredores.GetLength(0); i++)
                {

                    int j = 0;


                    if (id == corredores[i, j])
                    {

                        corredores[i, j] = "-1";
                        corredores[i, ++j] = "EspacioDisponible";
                        corredores[i, ++j] = "EspacioDisponible";
                        corredores[i, ++j] = "EspacioDisponible";
                        corredores[i, ++j] = "EspacioDisponible";

                        break;

                    }

                }

                for (int i = 0; i < carreras.GetLength(0); i++)
                {

                    int j = 0;

                    if (Convert.ToInt32(id) == carreras[i, j])
                    {

                        carreras[i, j] = -1;
                        carreras[i, ++j] = -1;
                        carreras[i, ++j] = -1;
                        carreras[i, ++j] = -1;
                        carreras[i, ++j] = -1;

                        break;

                    }

                }


                for (int i = 0; i < idPosUltimaCarrera.Length; i++)
                {

                    if (id == idPosUltimaCarrera[i])
                    {

                        idPosUltimaCarrera[i] = "-1";
                        posUltimaCarrera[i] = -1;

                        break;

                    }

                }

                Console.Clear();


                Console.WriteLine();
                Console.WriteLine($"El corredor con el id \"{id}\" ha sido eliminado correctamente");

            }
            else
            {

                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("Se seleccionó no eliminar");

            }


            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

        }

        /// <summary>
        /// Nos cuenta los corredores actuales sin tener en cuenta los espacios disponibles
        /// </summary>
        /// <param name="corredores"></param>
        /// <returns></returns>
        public static int ContarCorredoresActuales(string[,] corredores)
        {

            string idNulo = "-1";
            int corredoresNum = 0;


            for (int i = 0; i < corredores.GetLength(0); i++)
            {

                if (corredores[i, 0] != idNulo)
                {

                    corredoresNum++;

                }

            }

            return corredoresNum;

        }

        /// <summary>
        /// Se encarga de mostrar los corredores ordenados por puntaje ascendente mostrando desde el que está en en la 1era posición hasta los demás
        /// </summary>
        /// <param name="corredores"></param>
        /// <param name="carreras"></param>
        public static void OrdenarCarreraPuntaje(string[,] corredores, int[,] carreras)
        {

            bool flag = true;
            string fila = "";
            int largoFila = 0;
            string divisor = "-";
            int contador = 0;
            bool encontrado = false;
            int contadorPos = 0;


            for (int i = 0; i < carreras.GetLength(0) && flag; i++)
            {

                flag = false;

                for (int j = 0; j < carreras.GetLength(0) - i - 1; j++)
                {

                    if (carreras[j, carreras.GetLength(1) - 1] < carreras[j + 1, carreras.GetLength(1) - 1])
                    {

                        flag = true;

                        for (int k = 0; k < carreras.GetLength(1); k++)
                        {

                            int aux = carreras[j, k];
                            carreras[j, k] = carreras[j + 1, k];
                            carreras[j + 1, k] = aux;

                        }

                    }

                }

            }


            Console.Clear();
            Console.WriteLine();

            fila = String.Format("|{0,-5}| {1,-5}| {2, -15}| {3,-15}| {4,-15}| {5,-15}| {6,-10}| {7,-10}| {8,-10}| {9,-10}| ",
                "Pos.", "id", "Nombre", "Carac.", "Marca", "Color", "Pos Car 1", "Pos Car 2", "Pos Car 3", "Puntaje");

            Console.ForegroundColor = ConsoleColor.Green;

            Menu.ArmarFilaCabecera(fila);

            Console.ForegroundColor = ConsoleColor.White;


            for (int i = 0; i < carreras.GetLength(0); i++)
            {

                if (carreras[i, 0] != -1)
                {

                    encontrado = false;

                    for (int j = 0; j < corredores.GetLength(0); j++)
                    {

                        for (int k = 0; k < corredores.GetLength(1); k++)
                        {

                            if (Convert.ToInt32(corredores[j, 0]) == carreras[i, 0])
                            {

                                if (k == 0)
                                {

                                    Console.Write($"|{++contadorPos + "°",-5} |");
                                    Console.Write($"{corredores[j, k],-5} |");

                                    largoFila += 13;

                                    encontrado = true;

                                }
                                else
                                {

                                    Console.Write($"{corredores[j, k],-15}| ");

                                    largoFila += 17;

                                }

                            }

                        }

                        if (encontrado)
                        {
                            break;
                        }

                    }


                    for (int j = 1; j < carreras.GetLength(1); j++)
                    {

                        if (carreras[i, j] != 0)
                        {

                            Console.Write($"{carreras[i, j],-10}| ");

                            largoFila += 12;

                        }
                        else
                        {

                            Console.Write($"{"N/C",-10}| ");

                            largoFila += 12;

                        }


                    }

                    Console.WriteLine();

                    for (int j = 0; j < largoFila; j++)
                    {

                        Console.Write(divisor);

                    }

                    Console.WriteLine();

                    largoFila = 0;

                    contador++;

                }

            }

            if (contador == 0)
            {

                Console.WriteLine();
                Console.WriteLine("No hay corredores");

            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }


    }
}
