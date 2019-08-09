using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Student
    {
        public string Name { get; set; }
        public List<string> Courses { get; set; }
        public Student()
        {
            Courses = new List<string>();
        }
    }
    public static class CommonUtil
    {
        public static string ListToString(this IList<string> list)
        {
            StringBuilder result = new StringBuilder("");

            if (list.Count > 0)
            {
                result.Append(list[0].ToString());
                for (int i = 1; i < list.Count; i++)
                    result.AppendFormat("- {0}", list[i].ToString());
            }
            return result.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int[] arr1 = {4, 1, 3, 6,-2};
            var product = arr1.Where(a=> a%2==0).Aggregate(1, (a, val) => a * val);
            Console.WriteLine(product);
            */


            /*
            List<string> arr = new List<string>{ "Шо", "Шо", "Та", "За", "Шо" };
            string result = arr.ListToString();
            Console.WriteLine(result);
            */


            
            List<Student> students = new List<Student>
            {
                new Student {Name="Bobak", Courses = new List<string> {"JS", "c#","CSS" }},
                new Student {Name="Tom", Courses = new List<string> {"c++", "java" }},
                new Student {Name="Georgea", Courses = new List<string> {"JS", "c++", "HTML","Phyton" }},
                new Student {Name="Huan", Courses = new List<string> {"c#", "phyton" }}
            };

            var selectedStudents = students.SelectMany(s => s.Courses,
                            (s, c) => new { Student = s, Cours = c })
                          .Where(s => s.Cours == "JS" && s.Student.Name.Contains("a"))
                          .Select(s => s.Student);
            foreach (var s in selectedStudents)
                Console.WriteLine(s.Name);
            ///////////////////////////////////////////////////////////////////////////////
            var selectedStudents2 = from s in students
                                    select new
                                    {
                                        SName = s.Name,
                                        CountOfCourses = s.Courses.Count
                                    };
            foreach (var s in selectedStudents2)
                Console.WriteLine($"{s.SName} - count of courses = {s.CountOfCourses}");
            ///////////////////////////////////////////////////////////////////////////////
            var studentsGroups = from st in students
                                 where (st.Courses.Count == (students.Select(s => s.Courses.Count)).Max())
                              group st by st.Courses.Count;

            foreach (IGrouping<int, Student> s in studentsGroups)
            {
                Console.WriteLine(s.Key);
                foreach (var t in s)
                    Console.WriteLine(t.Name);
                Console.WriteLine();
            }


            Console.ReadKey();

        }
    }
}
