using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable
{
    class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            if (p != null)
            {
                return this.Name.CompareTo(p.Name);
            }
            else
                throw new Exception("Unable to compare'");
        }
    }
    class AgeComparer :IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Age < y.Age) return 1;
            else if (x.Age > y.Age) return -1;
            else return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Name = "Bill", Age = 34 };
            Person p2 = new Person { Name = "Tom", Age = 23 };
            Person p3 = new Person { Name = "Alice", Age = 21 };

            Person[] people = new Person[] { p1, p2, p3 };

            Array.Sort(people);
            foreach (Person p in people)
            {
                Console.WriteLine($"{p.Name} --- {p.Age}");
            }
            Console.WriteLine(new string('-',30));

            Array.Sort(people, new AgeComparer());
            foreach (Person p in people)
            {
                Console.WriteLine($"{p.Name} --- {p.Age}");
            }

            int[] arr = { 2, 5, 4, 2, 1 };
            Array.Sort(arr);
            foreach (int a in arr)
                Console.WriteLine(a);

            Console.ReadKey();
        }
    }
}
