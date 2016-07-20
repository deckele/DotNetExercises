using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    public static class MyExtentionMethods
    {
        //Lab 4.1 (2)
        public static void CopyTo(this Object currentObject, Object otherObject)
        {
            var x = from property in currentObject.GetType().GetProperties()
                select property;



        }
    }
}
