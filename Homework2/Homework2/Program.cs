using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Ex Tax: $80.00";
            int indexOfDolar = a.IndexOf('$');
            int indexOfPoint = a.IndexOf('.');
            string c = a.Substring(indexOfDolar+1, a.Length - indexOfPoint -1);
            int b = Convert.ToInt32(c);
            
            Console.WriteLine(c);
            Console.WriteLine(b);
            /*
            Console.WriteLine("Enter count of numbers");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter {n} numbers:");
            int[] mas = new int[n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Convert.ToInt32(Console.ReadLine());
            }

            int tmp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        tmp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = tmp;
                    }
                }
            }
            Console.WriteLine("Result :");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
            */

            // min max
            /*
            Console.WriteLine("Enter count of numbers");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter {n} numbers:");
            int[] mas = new int[n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }
            Console.WriteLine("Result :");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
            */


            Console.ReadKey();
        }
    }
}
