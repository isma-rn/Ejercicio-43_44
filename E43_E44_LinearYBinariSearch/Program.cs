using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E43_E44_LinearYBinariSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            string opcion;
            do
            {
                Console.Clear();
                int[] prueba = ObtenerArregloEnterosConAleatorios(10, 99, 15);
                
                if (prueba != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Arreglo de enteros con número aleatorios:");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var v in prueba)
                        Console.Write("[{0}]", v);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nArreglo ordenado ascendentemente");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var v in OrdenarAscendente(prueba))
                        Console.Write("[{0}]", v);

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nIngrese algún número del arreglo:");
                        if (Int32.TryParse(Console.ReadLine(), out int numero))
                        {
                            int? resultado = BuscarPosicionConLS(prueba, numero);                            
                            if (resultado.HasValue)
                                Console.WriteLine("(Linear Search)La posición del numero es: {0}", resultado.Value);
                            else
                                Console.WriteLine("No se encontró el número... (Linear Search)");

                            resultado = BuscarPosicionConBS(prueba, numero);
                            if (resultado.HasValue)
                                Console.WriteLine("(Binary Search)La posición del numero es: {0}", resultado.Value);
                            else
                                Console.WriteLine("No se encontró el número... (Binary Search)");

                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error, valor ingresado, no válido");
                        }
                    } while (true);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, no se puedo obtener arreglo");
                }
                
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nn : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);

            } while (!salir);
        }
        public static int? BuscarPosicionConLS(int[] arreglo, int numero)
        {            
            if ( arreglo.Length>0 )
            {
                arreglo = OrdenarAscendente(arreglo);
                for (int i = 0; i<arreglo.Length; i++)
                    if (arreglo[i] == numero)
                        return i;
            }
            return null;
        }
        public static int? BuscarPosicionConBS(int[] arreglo, int numero)
        {
            if ( arreglo.Length > 0 )
            {
                arreglo = OrdenarAscendente(arreglo);
                int l = 0, r = arreglo.Length - 1, m = 0;
                while ( l < r )
                {
                    m = (l + r) / 2;
                    if (arreglo[m] == numero)
                        return m;
                    else                    
                        if (arreglo[m] < numero)
                            l = m++;
                        else
                            r = m--;
                }
                
            }
            return null;
        }
        public static int[] ObtenerArregloEnterosConAleatorios(int min, int max, int size)
        {
            if (size > 0 && min < max)
            {
                Random random = new Random();
                int[] resultado = new int[size];
                for (int i = 0; i < size; i++)
                    resultado[i] = random.Next(min, max);
                return resultado;
            }
            return null;
        }
        public static int[] OrdenarAscendente(int[] arreglo)
        {
            int t;
            for (int a = 1; a < arreglo.Length; a++)
                for (int b = arreglo.Length - 1; b >= a; b--)
                {
                    if (arreglo[b - 1] > arreglo[b])
                    {
                        t = arreglo[b - 1];
                        arreglo[b - 1] = arreglo[b];
                        arreglo[b] = t;
                    }
                }
            return arreglo;
        }
    }
}
