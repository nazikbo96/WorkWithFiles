using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3, 4] { {4,8,4,5},{3,9,6,7},{1,12,3,4} };
            int rows = arr.GetUpperBound(0) + 1;
            int colloms = arr.Length / rows;

            int MaxSumRows = 0;
            int IOfMaxRow = 0;

            for (int i = 0;i<rows;i++)
            {
                int SumRows = 0;
                for (int j = 0;j<colloms;j++)
                {
                    SumRows += arr[i,j];
                }
                if(SumRows>MaxSumRows)
                {
                    MaxSumRows = SumRows;
                    IOfMaxRow = i;
                }
            }
            Console.WriteLine($"In row {IOfMaxRow+1} max Summ is {MaxSumRows}");
            /////////////////////////////////////////////////////////////////////////////////////////
            int IOfMaxCollom = 0;
            int MaxSumColloms = 0;
            for (int j = 0; j < colloms; j++)
            {
                int SumCollom = 0;
                for (int i = 0; i < rows; i++)
                {
                    SumCollom += arr[i, j];
                }
                if (SumCollom > MaxSumColloms)
                {
                    MaxSumColloms = SumCollom;
                    IOfMaxCollom = j;
                }
            }
            Console.WriteLine($"In collom {IOfMaxCollom + 1} max Summ is {MaxSumColloms}");
            Console.ReadKey();
        }
    }
}
