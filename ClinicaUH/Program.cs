// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;


int tamano = 2;
string[] nombre = new string[tamano];
int[] edad = new int[tamano];
string[] cita =  new string[tamano];
int opcion = 0;

menu();

void inicializar ()
{
    nombre = Enumerable.Repeat("", tamano).ToArray<string>();
    cita = Enumerable.Repeat("", tamano).ToArray<string>();
    edad = Enumerable.Repeat(0, tamano).ToArray<int>();
    
    Console.WriteLine("Los arreglos se inicializaron correctamente");
    Console.WriteLine("");
    Console.ReadKey();
    Console.Clear();

}

void agregar()
{
    for (int i = 0; i < tamano; i++)
    {
        Console.Write("Ingrese el nombre: ");
        nombre[i] = Console.ReadLine();

        // Validación de entrada para la edad
        bool edadValida = false;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ingrese la edad: ");
            string inputEdad = Console.ReadLine();

            if (!int.TryParse(inputEdad, out edad[i]))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("La edad ingresada no es un número entero válido. Por favor, intente de nuevo.");
            }
            else
            {
                edadValida = true;
            }

        } while (!edadValida);
    }
}





void consulta()
{
    bool encontrado =  false;
    Console.WriteLine("Digite el nombre a buscar");
    string nomb = Console.ReadLine();
    
    for (int i = 0; i < nombre.Length; i++)
    {
        if (nomb.Equals(nombre[i]))
        {
            Console.WriteLine($"La edad de {nomb} es {edad[i]}");
            encontrado = true;
        }
    }
    if (encontrado == false)
    { 
        Console.WriteLine($"El paciente {nomb} no existe");

    }
}

void reporte()
{
    //Reporte de la informacion digitada
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("{0,-20} {1,-5} {2,-30}", "Nombre", "Edad", "   Cita");
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("{0,-20} {1,-5} {2,-30}", "-------", "-------", "-----------------------------");

    for (int i = 0; i < tamano; i++)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0,-20} {1,-5} {2,-30}", nombre[i], edad[i], cita[i]);
    }
}


void asignar_cita()
{
    for (int i = 0; i < tamano; i++)
    {
        Console.Write("Ingrese el nombre del paciente ya registrado: ");
        string nombrePaciente = Console.ReadLine();

        bool encontrado = false;
        int indiceEncontrado = -1;

        for (int j = 0; j < nombre.Length; j++)
        {
            if (nombrePaciente.Equals(nombre[j]))
            {
                encontrado = true;
                indiceEncontrado = j;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine($"El paciente {nombrePaciente} no existe");
            continue;  // Reinicia el bucle para el próximo paciente
        }

        Console.Write($"¿{nombrePaciente} necesita asignar una cita? (Sí/No): ");
        string respuesta = Console.ReadLine().Trim().ToUpper();

        if (respuesta == "SI" || respuesta == "SÍ")
        {
            // Mini menú para elegir el día de la semana
            Console.WriteLine("Elija el día de la semana:");
            Console.WriteLine("1- Lunes");
            Console.WriteLine("2- Martes");
            Console.WriteLine("3- Miércoles");
            Console.WriteLine("4- Jueves");
            Console.WriteLine("5- Viernes");
            Console.WriteLine("6- Sábado");
            Console.WriteLine("7- Domingo");
            Console.Write("Ingrese el número del día: ");

            int opcionDia;
            while (!int.TryParse(Console.ReadLine(), out opcionDia) || opcionDia < 1 || opcionDia > 7)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("La opción ingresada no es válida. Ingrese nuevamente el número del día");
                Console.ResetColor();
            }

            // Mini menú para elegir el tipo de cita
            Console.WriteLine("Elija el tipo de cita:");
            Console.WriteLine("1- Cita General");
            Console.WriteLine("2- Cita por Odontología");
            Console.WriteLine("3- Cita por Terapia");
            Console.Write("Ingrese la opción: ");

            int opcionTipoCita;
            while (!int.TryParse(Console.ReadLine(), out opcionTipoCita) || opcionTipoCita < 1 || opcionTipoCita > 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("La opción ingresada no es válida. Ingrese nuevamente el número del tipo de cita");
                Console.ResetColor();
            }

            // Almacena la información de la cita en el paciente correcto
            cita[indiceEncontrado] = $"Cita el día {ObtenerNombreDia(opcionDia)} - Tipo: {ObtenerNombreTipoCita(opcionTipoCita)}";

            // Información de la cita asignada
            Console.WriteLine($"Cita asignada para {nombrePaciente} el día {ObtenerNombreDia(opcionDia)} - Tipo: {ObtenerNombreTipoCita(opcionTipoCita)}");

        }
    }
}

string ObtenerNombreTipoCita(int numeroTipoCita)
{
    switch (numeroTipoCita)
    {
        case 1: return "Cita General";
        case 2: return "Cita por Odontología";
        case 3: return "Cita por Terapia";
        default: return "Desconocido";
    }
}



string ObtenerNombreDia(int numeroDia)
{
    switch (numeroDia)
    {
        case 1: return "Lunes";
        case 2: return "Martes";
        case 3: return "Miércoles";
        case 4: return "Jueves";
        case 5: return "Viernes";
        case 6: return "Sábado";
        case 7: return "Domingo";
        default: return "Desconocido";
    }
}


void menu()
{
    int opcion;

    do
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("*********** Consultorio Medico ***********");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("1- Inicializar arreglos");
        Console.WriteLine("2- Ingresar paciente");
        Console.WriteLine("3- Consultar paciente");
        Console.WriteLine("4- Reporte");
        Console.WriteLine("5- Asignar citas"); // Tarea
        Console.WriteLine("6- Salir");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Digite una opcion");

        // Validación de la eleccion de la opcion
        string input = Console.ReadLine();
        if (!int.TryParse(input, out opcion))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Lo digitado no es un número entero válido. Por favor, intente de nuevo");
            Console.WriteLine();
            continue;  // Reiniciar el bucle para que el usuario ingrese una entrada valida
        }

        switch (opcion)
        {
            case 1:
                inicializar();
                Console.Clear();
                break;

            case 2:
                agregar();
                Console.Clear();
                break;

            case 3:
                consulta();
                Console.WriteLine();
                Console.WriteLine("Toque cualquier tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                break;

            case 4:
                reporte();
                Console.WriteLine();
                Console.WriteLine("Toque cualquier tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                break;

            case 5:
                asignar_cita();
                // Tarea
                break;

            case 6:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Gracias por usar el sistema de la Clinica UPI");
                break;

            default:
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("La opcion digitada no es la correcta");
                Console.WriteLine("Por favor, digite una opción entre 1 y 6");
                Console.WriteLine();
                break;
        }

    } while (opcion != 6);
}
