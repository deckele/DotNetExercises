using System;
using ShapeLib;
using System.Text;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeManager manager1 = new ShapeManager();
            manager1.AddShape(new Circle(2.5f));
            manager1.AddShape(new Circle(ConsoleColor.Red, 10));
            manager1.AddShape(new Ellipse(2, 4));
            manager1.AddShape(new Ellipse(ConsoleColor.Magenta, 2, 4));
            manager1.AddShape(new Rectangle(4, 5));
            manager1.AddShape(new Rectangle(ConsoleColor.DarkYellow, 8.25f, 2.5f));

            Console.WriteLine("Overall number of shapes in list: {0}.", manager1.Count);
            manager1.DisplayAll();
            Console.BackgroundColor = ConsoleColor.Black;

            StringBuilder sb = new StringBuilder();
            manager1.Save(sb);
            Console.WriteLine(sb.ToString());

            manager1.ShapeCompare((IComparable)manager1[1], (IComparable)manager1[2]);
            manager1.ShapeCompare((IComparable)manager1[3], (IComparable)manager1[3]);
            manager1.ShapeCompare((IComparable)manager1[3], (IComparable)manager1[4]);

            manager1.WriteSortedShapeList();

            Console.ReadLine();
        }
    }
}
