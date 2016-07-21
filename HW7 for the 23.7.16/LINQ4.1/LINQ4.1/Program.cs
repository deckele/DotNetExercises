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
            Console.WriteLine("LAB 4.1 (1.a):");
            Console.WriteLine();

            var assemblyQueryTool = new AssemblyPublicInterfaceQuery();
            var msCoreLibAssembly = typeof(string).Assembly;
            var typsInAssembly = assemblyQueryTool.GetSortedList(msCoreLibAssembly);

            Console.WriteLine($"List of public Interfaces and number of methods in each type for assembly- {msCoreLibAssembly}:");
            Console.WriteLine();

            foreach (var type in typsInAssembly)
            {
                Console.WriteLine(type);
                Console.WriteLine($"Number of methods in public interface: {type.GetMethods().Count()}.");
            }

            //LAB 4.1 (1.b+C)
            Console.WriteLine();
            Console.WriteLine("LAB 4.1 (1.b+C):");
            Console.WriteLine();

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
                    if (processDisplayerTool.CanAccessTimeStart(process))
                    {
                        Console.WriteLine($"Process Name: {process.ProcessName}.  Process ID: {process.Id}.  Process Starting time: {process.StartTime}.  Process number of threads: {process.Threads.Count}.");
                    }
                    else
                    {
                        Console.WriteLine($"Process Name: {process.ProcessName}.  Process ID: {process.Id}.  Process Starting time: Access Denied!  Process number of threads: {process.Threads.Count}.");
                    }
                }
            }

            //LAB 4.1 (1.d)
            Console.WriteLine();
            Console.WriteLine("LAB 4.1 (1.d):");
            Console.WriteLine();

            var threadCounterTool = new ThreadCounter();
            Console.WriteLine($"Total number of threads in system:  {threadCounterTool.Count()}");

            //Lab 4.1 (2)
            Console.WriteLine();
            Console.WriteLine("Lab 4.1 (2):");
            Console.WriteLine();

            var testOriginalObject = new TestClassForQ2N1("Lachman", new List<int>() { 5000, 8000, 7000 }, 1.70, 86, true, "Sematary");
            var testTargetObject = new TestClassForQ2N1("Miley", new List<int>() { 15000, 18000, 17000 }, 1.50, 27, false, "HollyWood");
            var testTargetObject2 = new TestClassForQ2N2("Miley", new List<string>() { "15000", "18000", "17000" }, 1.50, 75, false, "HollyWood");

            Console.WriteLine();
            Console.WriteLine("Test 1: Testing CopyTo() on two objects from same type TestClassForQ2N1");
            Console.WriteLine("Test 1 - before extention method- CopyTo():");
            Console.WriteLine(testOriginalObject);
            Console.WriteLine(testTargetObject);

            testOriginalObject.CopyTo(testTargetObject);
            Console.WriteLine("Test 1 - after extention method- CopyTo():");
            Console.WriteLine(testTargetObject);

            Console.WriteLine();
            testTargetObject.TestCopy(testOriginalObject, testTargetObject);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Test 2: Testing CopyTo() on two objects from different types: TestClassForQ2N1 and TestClassForQ2N2");
            Console.WriteLine("Test 2 - before extention method- CopyTo():");
            Console.WriteLine(testOriginalObject);
            Console.WriteLine(testTargetObject2);

            testOriginalObject.CopyTo(testTargetObject2);
            Console.WriteLine("Test 2 - after extention method- CopyTo():");
            Console.WriteLine(testTargetObject2);

            Console.WriteLine();
            testTargetObject2.TestCopyDifferentType(testOriginalObject, testTargetObject2);
            Console.WriteLine();
            Console.WriteLine("All tests turned out as expected.");
        }
    }
}
