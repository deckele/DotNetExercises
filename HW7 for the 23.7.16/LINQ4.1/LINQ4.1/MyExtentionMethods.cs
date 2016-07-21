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
        public static void CopyTo(this object originalObject, object targetObject)
        {
            if (targetObject == null)
            {
                return;
            }

            var propertiesQuery = from originalProperty in originalObject.GetType().GetProperties()
                                  where originalProperty.CanRead
                                  from targetProperty in targetObject.GetType().GetProperties()
                                  where targetProperty.CanWrite
                                  where (targetProperty.Name == originalProperty.Name) &&
                                  (targetProperty.PropertyType == originalProperty.PropertyType)                                  
                                  select new
                                  {
                                      original = originalProperty,
                                      target = targetProperty
                                  };

            foreach (var property in propertiesQuery)
            {
                property.target.SetValue(targetObject, property.original.GetValue(originalObject));
            }
        }
    }
}
