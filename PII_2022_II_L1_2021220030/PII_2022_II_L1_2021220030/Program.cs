using PII_2022_II_L1_2021220030.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace PII_2022_II_L1_2021220030
{
    internal class Program
    {
        static JuegoDiario[] personas;
        static JuegoSemanal[] personasSemanal;
        static JuegoMensual personasMensual;
        static void Main(string[] args)
        {
            
            int op = 1;
            while (op > 0)
            {
                try
                {
                    Console.Clear();
                    imprimirMenu();
                    WriteLine("\nElija una opción");
                    op = int.Parse(ReadLine());
                    Console.Clear();
                    switch (op)
                    {
                        case 0:
                            Console.WriteLine("***Ha finalizado el Programa***");
                            break;
                        case 1:
                            VenderDiario();
                            break;
                        case 2:
                            VenderSemanal();
                            break;
                        case 3:
                            VenderMensual();
                            break;
                        case 4:
                            juegoDiario();
                            break;
                        case 5:
                            juegoSemanal();
                            break;
                        case 6:
                            juegoMensual();
                            break;
                        default:
                            Console.WriteLine("Opción no válida!");
                            break ;
                    }
                }catch(Exception)
                {
                }
                ReadLine();
            }
        }

        private static void imprimirMenu()
        {
            WriteLine("========= JUEGOS ========\n");

            WriteLine("1- Vender Diario");
            WriteLine("2- Vender Semanal");
            WriteLine("3- Vender Mensual");
            WriteLine("4- Juego Diario");
            WriteLine("5- Juego Semanal");
            WriteLine("6- Juego Mensual");
            WriteLine("0- Salir");
        }
       
        private static void VenderDiario()
        {
            string nombre;
            int cantPersonas;

            WriteLine("=============== VENDER DIARIO ===============\n");

            WriteLine("Ingrese la cantidad de clientes: ");
            cantPersonas = int.Parse(ReadLine());
            personas = new JuegoDiario[cantPersonas];

            for (int i = 0; i < cantPersonas; i++)
            {
                Console.WriteLine($"\nIngrese su nombre");
                nombre = ReadLine();
                int index = 0;
                int[] numeros = new int[5];

                int numero;

                Console.WriteLine("\nIngrese los números a comprar");
                while (index < 5)
                {
                    WriteLine($"Ingrese el número {index + 1}:");
                    numero = int.Parse(ReadLine());

                    while(numero > 100 || numero < 0)
                    {
                        WriteLine("El número no puede ser mayor a 100 ni menor a 0");
                        WriteLine($"Ingrese el número {index + 1}:");
                        numero = int.Parse(ReadLine());
                    }
                    if (Array.IndexOf(numeros, numero) > -1)
                    {
                        Console.WriteLine("El numero ingresado ya ha sido comprado");
                    }
                    else
                    {
                        numeros[index] = numero;
                        index++;
                    }
                }
                personas[i] = new JuegoDiario(nombre, numeros);
                WriteLine("Guardado!");
            }
            
        }

        private static void juegoDiario()

        {
            if (personas != null)
            {
                Random rdn = new Random();
                int numAleatorio;
                bool found = false;
                WriteLine("\nNumeros Ganadores");
                for (int i = 0; i < 5; i++)
                {
                    numAleatorio = rdn.Next(0, 100);
                    WriteLine($"{i + 1}. {numAleatorio}");
                    foreach (var persona in personas)
                    {
                        if (Array.IndexOf(persona.Numeros, numAleatorio) > -1)
                        {
                            persona.Cont++;
                        }
                    }
                }

                WriteLine("\n");
                WriteLine("Ganadores:");

                foreach (var persona in personas)
                {
                    if (persona.getGanador() != null) found = true;
                    WriteLine(persona.getGanador());
                }

                if (!found)
                {
                    WriteLine("No hay ganadores");
                }
            }
            else
            {
                WriteLine("Nadie a comprado aun");
            }
        }
        private static void VenderSemanal() {
            string nombre;
            int cantPersonas;

            WriteLine("=============== VENDER SEMANAL ===============\n");

            WriteLine("Ingrese la cantidad de clientes: ");
            cantPersonas = int.Parse(ReadLine());
            personasSemanal = new JuegoSemanal[cantPersonas];

            for (int i = 0; i < cantPersonas; i++)
            {
                Console.WriteLine($"\nIngrese su nombre");
                nombre = ReadLine();
                
                int numero1, numero2;

                Console.WriteLine("\nIngrese los números a comprar\n");
                WriteLine($"Ingrese el número 1:");
                numero1 = int.Parse(ReadLine());
                while(numero1 < 0 || numero1 > 100)
                {
                    WriteLine($"El número no puede ser mayor a 100 ni menor a 0");
                    WriteLine($"Ingrese el número 1:");
                    numero1 = int.Parse(ReadLine());
                }
                WriteLine($"Ingrese el número 2:");
                numero2 = int.Parse(ReadLine());
                while (numero2 < 0 || numero2 > 100)
                {
                    WriteLine($"El número no puede ser mayor a 100 ni menor a 0");
                    WriteLine($"Ingrese el número 2:");
                    numero2 = int.Parse(ReadLine());
                }
                while (numero1==numero2)
                {
                    Console.WriteLine("El numero ingresado ya ha sido comprado, ingrese uno diferente.");
                    WriteLine($"Ingrese el número 2:");
                    numero2 = int.Parse(ReadLine());
                }
                personasSemanal[i] = new JuegoSemanal(nombre, numero1, numero2);
                WriteLine("Guardado!");
            }
        }

        private static void juegoSemanal() {
            if (personasSemanal != null)
            {
                Random rdn = new Random();
                int numAleatorio1 = rdn.Next(0, 100);
                int numAleatorio2 = rdn.Next(0, 100);

                bool found = false;
                WriteLine("Números ganadores:");
                WriteLine(numAleatorio1);
                WriteLine(numAleatorio2);
                WriteLine("\n");
                WriteLine("Ganadores:");
                foreach (var persona in personasSemanal)
                {
                    if (persona.getGanador(numAleatorio1, numAleatorio2) != null) found = true;
                    WriteLine(persona.getGanador(numAleatorio1, numAleatorio2));
                }

                if (!found)
                {
                    WriteLine("No hay ganadores");
                }
            }
            else
            {
                WriteLine("Nadie a comprado aun");
            }

        }

        private static void VenderMensual() {
            string nombre;
            int cantPersonas, numero;
            personasMensual = new JuegoMensual();
            WriteLine("=============== VENDER MENSUAL ===============\n");

            WriteLine("Ingrese la cantidad de clientes: ");
            cantPersonas = int.Parse(ReadLine());

            for (int i = 0; i < cantPersonas; i++)
            {
                WriteLine("Ingrese el nombre");
                nombre = ReadLine();
                WriteLine("Ingrese el número a comprar");
                numero  = int.Parse(ReadLine());
                while (numero>100 || numero<0)
                {
                    WriteLine("El numero no puede ser mayor a 100 ni menor a 0");
                    WriteLine("Ingrese el número a comprar");
                    numero = int.Parse(ReadLine());                    
                }
                while (!string.IsNullOrEmpty(personasMensual.Personas[numero]))
                {
                    WriteLine("El numero ya ha sido comprado!, ingrese uno distinto.");
                    WriteLine("Ingrese el número a comprar");
                    numero = int.Parse(ReadLine());
                }
                personasMensual.Personas[numero] = nombre;
                WriteLine("Guardado!");

            }
            
        }

        private static void juegoMensual() {
            if (personasMensual != null)
            {
                Random rdn = new Random();
                int numAleatorio = rdn.Next(0, 3);
                WriteLine($"Numero Ganador: {numAleatorio}");
                WriteLine("Ganador de los L. 10000:");
                WriteLine(personasMensual.getGanador(numAleatorio));
            }
            else
            {
                WriteLine("Nadie a comprado aun");
            }
        }
    }
}
