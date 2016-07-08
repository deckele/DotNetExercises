using System;
using System.Collections;
using ShapeLib;
using System.Text;

namespace ShapesApp
{
    class ShapeManager
    {
        private ArrayList shapeList;
        public Shape this[int index]
        {
            get
            {
                return (Shape)shapeList[index];
            }
        }
        public int Count
        {
            get
            {
                return shapeList.Count;
            }
        }

        public ShapeManager()
        {
            shapeList = new ArrayList();
        }

        public void AddShape(Shape shape)
        {
            shapeList.Add(shape);
        }
        public void DisplayAll()
        {
            foreach (Shape shape in shapeList)
            {
                shape.Display();
                Console.WriteLine("Area = {0}.", shape.Area);
            }
        }

        public void Save(StringBuilder sb)
        {
            foreach (Shape shape in shapeList)
            {
                if (shape is IPersist)
                {
                    ((IPersist)shape).Write(sb);
                }
            }
        }

        //Method gets two IComparable shapes, and writes to console who is bigger.
        public void ShapeCompare(IComparable shape1, IComparable shape2)
        {
            int compare = shape1.CompareTo(shape2);
            if (compare > 0)
            {
                Console.WriteLine("First shape is bigger.");
            }
            else if (compare < 0)
            {
                Console.WriteLine("Second shape is bigger.");
            }
            else
            {
                Console.WriteLine("Shapes are equal in size.");
            }
        }

        //This Method was written for testing of the IComparable interface implementation.
        public void WriteSortedShapeList()
        {
            this.shapeList.Sort();
            foreach (Shape shape in shapeList)
            {
                Console.WriteLine("{0} : {1}", shape.ToString(), shape.Area);
            }
        }
    }
}
