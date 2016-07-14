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
            var assemblyAnalyzer = new AssemblyAnalyzer(Assembly.GetExecutingAssembly());
        }
    }
}
