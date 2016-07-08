using System;

namespace ShapeLib
{
    public abstract class Shape
    {
        public abstract float Area{get;}
        protected ConsoleColor Color {get; private set;}

        internal Shape(ConsoleColor color)
        {
            Color = color;
        }
        internal Shape() : this(ConsoleColor.White) { }
        //Sets console background color according to the Color property.
        public virtual void Display()
        {
            Console.BackgroundColor = Color;
        }
    }
}
