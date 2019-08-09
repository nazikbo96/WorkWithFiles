using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Pond<T>
    {
        public static T NamePond;

        public T Id { get; set; }
        public int CountFish { get; set; }
    }
    class Perevod<U, V>
    {
        public U FromPond { get; set; }
        public U ToPond { get; set; }
        public V CodeOfPerevod { get; set; }        
        public int CountFish { get; set; }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pond<int> pond1 = new Pond<int> { Id = 1857, CountFish = 12500 };
            Pond<int>.NamePond = 777;

            Pond<int> pond2 = new Pond<int> { Id = 3453, CountFish = 23000 };
            Pond<string>.NamePond = "RedPond";

            Console.WriteLine(Pond<int>.NamePond);
            Console.WriteLine(Pond<string>.NamePond);

            Perevod<Pond<int>, int> perevod1 = new Perevod<Pond<int>, int>
            {
                FromPond = pond1,
                ToPond = pond2,
                CodeOfPerevod = 8000,
                CountFish = 900
            };


            Console.ReadKey();
        }
    }
}
