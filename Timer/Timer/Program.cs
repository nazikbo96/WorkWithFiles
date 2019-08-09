using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{

    class Timer
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }

    class Counter
    {
        public int Seconds { get; set; }

        public static implicit operator Counter(int x)
        {
            return new Counter { Seconds = x };
        }
        public static explicit operator int(Counter counter)
        {
            return counter.Seconds;
        }
        public static explicit operator Counter(Timer timer)
        {
            int h = timer.Hours * 3600;
            int m = timer.Minutes * 60;
            return new Counter { Seconds = h + m + timer.Seconds };
        }
        public static implicit operator Timer(Counter counter)
        {
            int h = counter.Seconds / 3600;
            int m = (counter.Seconds - h * 3600) / 60;
            int s = counter.Seconds - h * 3600 - m * 60;
            return new Timer { Hours = h, Minutes = m, Seconds = s };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter { Seconds = 225 };

            Timer timer = counter1;
            Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}");

            Counter counter2 = (Counter)timer;
            Console.WriteLine(counter2.Seconds); 

            Console.ReadKey();



            Console.ReadKey();
        }
    }
}
