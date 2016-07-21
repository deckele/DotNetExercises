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
            var otherObjectProperties = from property in otherObject.GetType().GetProperties()
                where property.CanWrite
                select property;

            var currentObjectProperties = from property in currentObject.GetType().GetProperties()
                where property.CanRead
                where otherObjectProperties.Contains(property)
                select property;

        }
    }
}
