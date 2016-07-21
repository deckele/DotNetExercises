using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    internal class AssemblyPublicInterfaceQuery
    {
        public IOrderedEnumerable<Type> GetSortedList(Assembly assemblyToQuery)
        {
            //Alternative code without LINQ syntax sugar:
            //var typsInAssembly = assemblyToQuarry.GetExportedTypes().Where(type => type.IsInterface)
            //    .OrderBy(type => type.TypeHandle.ToString());

            var typsInAssemblyQuery = from type in assemblyToQuery.GetExportedTypes()
                where type.IsInterface
                orderby type.TypeHandle.ToString()
                select type;

            return typsInAssemblyQuery;
        }
    }
}

