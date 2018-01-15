using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1Numeros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Declaro variables
            int menosRep1 = 0, menosRep2 = 0, numMenosRep = 0, numIgualRep = 0, numIgualCount = 0, numMasRep, numMayor, numMenor;

            Console.WriteLine("Ingrese los numeros separados por comas");

            string nums1 = Console.ReadLine();

            string[] nums2 = nums1.Split(',');

            int[] myInts = nums2.Select(int.Parse).ToArray();
            
            //Obtengo Mayor y Menor
             numMayor = myInts.Max();
             numMenor = myInts.Min();

            double myProm = promedio(myInts);

            //Obtengo el numero mas repeticiones
            numMasRep = myInts.GroupBy(x => x).OrderByDescending(g => g.Count()).First().First();
            
            //Obtengo el numero con menos repeticiones
            foreach (var grouping in myInts.GroupBy(t => t).Where(t => t.Count() != 1))
            {
                if (menosRep1 == 0)
                {
                    menosRep1 = grouping.Count();
                    numMenosRep = grouping.Key;
                }

                if (grouping.Count() < menosRep1)
                {
                    menosRep2 = grouping.Count();

                    numMenosRep = grouping.Key;
                }
                if (grouping.Key == grouping.Count())
                {
                    numIgualRep = grouping.Key;
                    numIgualCount = grouping.Count();
                }

            }

            Console.WriteLine("El promedio es: '{0}'", myProm);
            Console.WriteLine("El mayor es:'{0}' ", numMayor);
            Console.WriteLine("El menor es:'{0}' ", numMenor);
            Console.WriteLine("El mas repetido es:'{0}' ", numMasRep);
            Console.WriteLine("El menos repetido es:'{0}' ", numMenosRep);
            
            //Si hay un numero con el mismo valor 
            foreach (var grouping in myInts.GroupBy(t => t).Where(t => t.Count() != 1))
            {
                if (grouping.Key == grouping.Count())
                    Console.WriteLine(string.Format("'{0}' está repetido {1} veces.", numIgualRep, numIgualCount));
            }

            Console.ReadKey();
        }
       
        #region Promedio

        //Calculo promedio
        public static double promedio(int[] enteros)
        {
            double totalProm = 0;

            foreach (int e in enteros)
            {
                totalProm += e;

            }

            totalProm = totalProm / enteros.Length;

            return totalProm;
        }
        #endregion
    }
}
