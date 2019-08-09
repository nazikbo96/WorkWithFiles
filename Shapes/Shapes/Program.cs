using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    public abstract class Shape                      //Shape
    {
        public string name;              //field
        public string Name { get; set; }        // property

        public Shape(string name)            // constructor
        {
            Name = name;
        }
        public abstract double Area();
        public abstract double Perimeter();
    }
    class Circle : Shape                //circle
    {
        public int Radius;
        public Circle(string name, int radius)
        : base(name)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return 3.14 * this.Radius * this.Radius;
        }

        public override double Perimeter()
        {
            return 2 * 3.14 * this.Radius;
        }
    }
    class Square : Shape                            //square
    {
        public int Side;
        public Square(string name, int side)
        : base(name)
        {
            Side = side;
        }
        public override double Area()
        {
            return this.Side * this.Side;
        }

        public override double Perimeter()
        {
            return this.Side * 4;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter name of the Shape");
                string chekShape = Convert.ToString(Console.ReadLine());
                if (chekShape == "circle")
                {
                    Console.WriteLine("Enter radius");
                    shapes.Add(new Circle(chekShape, Convert.ToInt32(Console.ReadLine())));
                }
                else if (chekShape == "square")
                {
                    Console.WriteLine("Enter side");
                    shapes.Add(new Square(chekShape, Convert.ToInt32(Console.ReadLine())));
                }
                else
                {
                    Console.WriteLine("You enter wrong shape");
                    i--;
                }
            }
            foreach (var s in shapes)
            {
                Console.WriteLine($"Area of {s.Name} is {s.Area()}");
                Console.WriteLine($"Perimeter of {s.Name} is {s.Perimeter()}");
                Console.WriteLine("\n");
            }
            Shape maxPerimeter = shapes.FirstOrDefault();                  //max
            foreach (var s in shapes)
            {
                if (s.Perimeter() > maxPerimeter.Perimeter())
                {
                    maxPerimeter = s;
                }
            }
            Console.WriteLine($"Max perimeter is {maxPerimeter.Perimeter()} in shape {maxPerimeter.Name}");

            var shapesSortByArea = shapes.OrderByDescending(item => item.Area()).ToList();             //sort

            foreach (Shape u in shapesSortByArea)
                Console.WriteLine($"Shape {u.Name} have area {u.Area()}");

            Console.ReadLine();
        }
    }
}