using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building projects asynchronously:");
            var concurrentBuilder = new ConcurrentBuilder();
            concurrentBuilder.Build();

            Console.WriteLine();
            Console.WriteLine("Building projects synchronously:");
            var sequentialBuilder = new SequentialBuilder();
            sequentialBuilder.Build();
        }
    }
}
