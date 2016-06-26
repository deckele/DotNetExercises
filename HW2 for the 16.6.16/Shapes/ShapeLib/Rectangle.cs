using System;
using System.Text;

namespace ShapeLib
{
    public class Rectangle : Shape, IPersist, IComparable
    {
        public float Hight { get; private set; }
        public float Width { get; private set; }

        public Rectangle(float hight, float width)
        {
            Hight = hight;
            Width = width;
        }
        public Rectangle(ConsoleColor color, float hight, float width) : base(color)
        {
            Hight = hight;
            Width = width;
        }

        public override float Area
        {
            get
            {
                return Hight * Width;
            }
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("The hight of your rectangle is: {0}.\nThe width of your rectangle is: {1}.", Hight, Width);
        }

        //Overriding Write() Method for the implementing of IPersist.
        public virtual void Write (StringBuilder sb)
        {
            sb.Append("Hight of rectangle is: ").Append(Hight.ToString()).
                Append(", width of rectangle is: ").Append(Width.ToString()).AppendLine(".");
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
