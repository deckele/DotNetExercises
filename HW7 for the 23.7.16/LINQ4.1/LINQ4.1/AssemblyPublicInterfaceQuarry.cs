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
        public void DisplaySortedList(Assembly assemblyToQuarry)
        {
            var typsInAssembly = assemblyToQuarry.GetExportedTypes().Where(type => type.IsInterface);
            var typsInAssemblyList = typsInAssembly.OrderBy(type => type.TypeHandle.ToString()).ToList();

            Console.WriteLine($"List of public Interfaces and number of methods in each type for assembly- {assemblyToQuarry}:");
            foreach (var type in typsInAssemblyList)
            {
                Console.WriteLine(type);
                Console.WriteLine($"Number of methods in public interface: {type.GetMethods().Count()}.");
            }
        }
    }
}

