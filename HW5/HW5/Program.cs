using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public double Rait { get; set; }
    }
    class Group
    {
        public string GroupNumber { get; set; }
        public string Napriam { get; set; }
        public double Avarage(List<Student> list)
        {
            int count = 0;
            double avarage = 0;
            for (int i = 0;i<list.Count;i++)
            {
                if (list[i].Group==this.GroupNumber)
                {
                    avarage += list[i].Rait;
                    count++;
                }
            }
            return avarage / count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
            new Student{Name =  "Vova",Group= "11",Rait= 88 },
            new Student{Name =  "Ira",Group= "11",Rait= 50 },
            new Student{Name =  "Kolia",Group= "12",Rait= 65 },
            new Student{Name =  "Nazar",Group= "12",Rait= 90 },
            new Student{Name =  "Goga",Group= "13",Rait= 55 },
            new Student{Name =  "Vika",Group= "14",Rait= 20 },
            };
            List<Group> groups = new List<Group>
            {
                new Group{GroupNumber = "11", Napriam ="KN"},
                new Group{GroupNumber = "12", Napriam ="KU"},
                new Group{GroupNumber = "13", Napriam ="KP"},
            };

            var studentsGroups = from st in students
                                 from gr in groups
                                 where st.Group == gr.GroupNumber
                              group st by st.Group;
            foreach(var r in groups)
                        Console.WriteLine($"{r.Avarage(students)} --- Avarage Raiting of group number {r.GroupNumber} ");
            Console.WriteLine();
            foreach (IGrouping<string, Student> s in studentsGroups)
            {
                Console.WriteLine($"{s.Key} - group");
                foreach (var t in s)
                {
                    Console.WriteLine($"{t.Name} - {t.Rait}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
