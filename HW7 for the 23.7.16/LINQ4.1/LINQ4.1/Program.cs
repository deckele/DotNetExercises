using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //LAB 4.1 (1.a)
            var assemblyQuarryTool = new AssemblyPublicInterfaceQuarry();
            var msCoreLibAssembly = typeof(string).Assembly;
            var typsInAssembly = assemblyQuarryTool.GetSortedList(msCoreLibAssembly);

            Console.WriteLine($"List of public Interfaces and number of methods in each type for assembly- {msCoreLibAssembly}:");
            Console.WriteLine();

            foreach (var type in typsInAssembly)
            {
                Console.WriteLine(type);
                Console.WriteLine($"Number of methods in public interface: {type.GetMethods().Count()}.");
            }

            //LAB 4.1 (1.b+C)
            var processDisplayerTool = new ProcessDisplayer();
            const int maxThreads = 4;
            var processesByPriority = processDisplayerTool.GetProcesses(maxThreads);

            Console.WriteLine();
            Console.WriteLine($"List of current system processes with less than {maxThreads} sorted by priority:");

            foreach (var priorityGroup in processesByPriority)
            {
                Console.WriteLine();
                Console.WriteLine($"Priority group is : {priorityGroup.Key}");

                foreach (var process in priorityGroup)
                {
                    Console.WriteLine($"Process Name: {process.ProcessName}.  Process ID: {process.Id}.  Process Starting time: .  Process number of threads: {process.Threads.Count}.");
                }
            }

            //LAB 4.1 (1.D)
            var threadCounterTool = new ThreadCounter();
            Console.WriteLine();
            Console.WriteLine($"Total number of threads in system:  {threadCounterTool.Count()}");

            //Lab 4.1 (2)
        }
    }
}
