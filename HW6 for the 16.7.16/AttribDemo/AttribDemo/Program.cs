using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyAnalyzer = new AssemblyAnalyzer();
            Console.WriteLine("Status all types in this assembly were approved: {0}.", 
                assemblyAnalyzer.AnalayzeAssembly(Assembly.GetExecutingAssembly()));
            Console.WriteLine();
            Console.WriteLine("Status all types in mscorlib assembly were approved: {0}.",
                assemblyAnalyzer.AnalayzeAssembly(typeof(string).Assembly));
        }
    }
}
