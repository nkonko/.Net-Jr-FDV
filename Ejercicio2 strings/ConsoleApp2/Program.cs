using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string lector, palabra;
            
            var listaPalabras = new List<string>();
            
            Console.WriteLine("Ingrese todas las palabras que quiera, para salir, simplemente ingrese 'salir' sin las comillas \r\n");

            do
            {
                lector = Console.ReadLine();

                string[] palabras = lector.Split(' ');

                if (lector != "salir")
                {

                    foreach (string p in palabras )
                    {
                        listaPalabras.Add(p.ToLower());
                    }

                }
                
            }while (lector != "salir");

                var strBuilder = new StringBuilder();

            foreach (var grouping in listaPalabras.GroupBy(t => t).Where(t => t.Count() != 1))
            {
                string auxArmado = "";

                palabra = grouping.Key;

                string armadoFinal;

                auxArmado = string.Format(char.ToUpper(palabra[0]) + palabra.Substring(1));

                armadoFinal = string.Concat(auxArmado, ",");

                strBuilder.Append(armadoFinal);

            }
            
            strBuilder.Remove(strBuilder.Length - 1, 1);

            strBuilder.Append(".");

            Console.WriteLine("\r\n '{0}'", strBuilder);
            Console.WriteLine("\r\n Presione una tecla para salir");
            Console.Read();
        }
    }
}
