using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    internal class AssemblyPublicInterfaceQuarry
    {
        public IOrderedEnumerable<Type> GetSortedList(Assembly assemblyToQuarry)
        {
            //Alternative code without LINQ syntax sugar:
            //var typsInAssembly = assemblyToQuarry.GetExportedTypes().Where(type => type.IsInterface);
            //var typsInAssemblyList = typsInAssembly.OrderBy(type => type.TypeHandle.ToString()).ToList();

            var typsInAssembly = from type in assemblyToQuarry.GetExportedTypes()
                where type.IsInterface
                orderby type.TypeHandle.ToString()
                select type;

            return typsInAssembly;
        }
    }
}

