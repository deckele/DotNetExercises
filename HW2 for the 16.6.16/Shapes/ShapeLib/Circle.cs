using System;
using System.Text;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        public float Radius { get; private set; }

        public Circle(float radius) : base(radius*2, radius*2)
        {
            Radius = radius;
        }
        public Circle(ConsoleColor color, float radius) : base(color, radius*2, radius*2)
        {
            Radius = radius;
        }

        public override float Area
        {
            get
            {
                return (float)Math.PI * Radius;
            }
        }
        public override void Display()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine("The radius of your circle is: {0}.", Radius);
        }

        //Overriding Write() Method for the implementing of IPersist.
        public override void Write(StringBuilder sb)
        {
            sb.Append("Radius of circle is: ").Append((Hight/2).ToString()).AppendLine(".");
        }
    }
}
