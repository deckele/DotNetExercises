using System;
using System.Text;

namespace ShapeLib
{
    public class Ellipse : Shape, IPersist, IComparable
    {
        public float Hight { get; private set; }
        public float Width { get; private set; }

        public Ellipse(float hight, float width)
        {
            Hight = hight;
            Width = width;
        }
        public Ellipse(ConsoleColor color, float hight, float width) : base(color)
        {
            Hight = hight;
            Width = width;
        }

        public override float Area
        {
            get
            {
                return (float)Math.PI * Hight * Width / 4;
            }
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("The major axis of your ellipse is: {0}.\nThe minor axis of your ellipse is: {1}.", 
                Math.Max(Hight, Width), Math.Min(Hight, Width));
        }

        //Overriding Write() Method for the implementing of IPersist.
        public virtual void Write(StringBuilder sb)
        {
            sb.Append("Major axis of ellips is: ").Append(Math.Max(Hight, Width).ToString()).
                Append(", minor axis of ellipse is: ").Append(Math.Min(Hight, Width).ToString()).AppendLine(".");
        }
        //Overriding CompareTo() Method for the implementing of IComparable.
        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Shape shape = obj as Shape;
            if (shape != null)
            {
                return this.Area.CompareTo(shape.Area);
            }
            else
            {
                throw new ArgumentException("Object compared is not a \"shape\".");
            }
        }
    }
}
