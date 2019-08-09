using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Person
    {
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Person person = (Person)obj;
            return (this.Name == person.Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person { Name = "Tom" };
            Person person2 = new Person { Name = "Bob" };
            Person person3 = new Person { Name = "Tom" };
            bool p1Ep2 = person1.Equals(person2);   // false
            bool p1Ep3 = person1.Equals(person3);   // true
            Console.WriteLine(p1Ep2);
            Console.WriteLine(p1Ep3);

            object o1 = 5, o2 = 5;
            bool eq = (o1 == o2); // false
            Console.WriteLine(eq);

            bool eq2 = o1.Equals(o2);
            Console.WriteLine(eq2);













            Console.ReadKey();
        }
    }
}

