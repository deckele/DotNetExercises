using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //LAB 4.1 (a)
            var assemblyToQuarry = new AssemblyPublicInterfaceQuarry();
            var msCoreLibAssembly = typeof(string).Assembly;
            var typsInAssembly = assemblyToQuarry.DisplaySortedList(msCoreLibAssembly);

            Console.WriteLine($"List of public Interfaces and number of methods in each type for assembly- {msCoreLibAssembly}:");
            Console.WriteLine();

            foreach (var type in typsInAssembly)
            {
                Console.WriteLine(type);
                Console.WriteLine($"Number of methods in public interface: {type.GetMethods().Count()}.");
            }

        }
    }
}
