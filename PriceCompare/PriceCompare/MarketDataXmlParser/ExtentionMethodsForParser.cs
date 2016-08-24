using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataXmlParser
{
    public static class ExtentionMethodsForParser
    {
        public static TValue ParseGenericType<TValue>(this object obj)
        {
            return (TValue)Convert.ChangeType(obj, typeof(TValue));
        }
    }
}
