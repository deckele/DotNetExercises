using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            var parallelismTimer = new Stopwatch();

            for (int i = 1; i <= 8; i++)
            {
                parallelismTimer.Start();
                PrimeFinder.CalcPrimes(0, 1000000, i);
                Console.WriteLine($"Time in milliseconds for CalcPrimes using {i} max tasks: {parallelismTimer.ElapsedMilliseconds}.");
                parallelismTimer.Reset();
                Console.WriteLine();
            }
        }
    }
}
