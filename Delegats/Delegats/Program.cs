using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegats
{
    public static class MyClass
    {
        public delegate bool Checker(double x);
        public static int SumVector(int[] arr, Checker del)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                if (del(i))
                {
                    sum += i;
                }
            }
            return sum;
        }
        public static int MaxValueVector(int[] arr, Checker del)
        {
            int tmp = arr[0];
            foreach (int i in arr)
            {
                if (del(i))
                {
                    if (i > tmp)
                    {
                        tmp = i;
                    }
                }
            }
            return tmp;
        }

        public static double AvarageVector(int[] arr,Checker del)
        {
            double sum = 0;
            int counter = 0;
            foreach (int i in arr)
            {
                if (del(i))
                {
                    sum += i;
                    counter++;
                }
            }
            return sum/counter;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5,5,5,5,-5,5,-5,5};

            Console.WriteLine($"{MyClass.SumVector(arr, i => i > 0)} - Summ");
            Console.WriteLine($"{MyClass.MaxValueVector(arr, i => i > 0)} - Max value");
            Console.WriteLine($"{MyClass.AvarageVector(arr, i => i > 0)}  - Avarage");

            Console.ReadKey();
        }
    }
}
