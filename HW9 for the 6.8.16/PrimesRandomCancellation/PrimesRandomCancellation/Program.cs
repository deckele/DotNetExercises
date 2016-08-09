using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimesRandomCancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Random cancel testing started. Calculating primes between 0 and 30,000,000.");
            Console.WriteLine();

            var randomCancelTimer = Stopwatch.StartNew();
            Console.WriteLine($"Action stopped after calculating: {PrimeFinder.CalcPrimes(0, 30000000).Length} primes.");
            Console.WriteLine($"Total time elapsed: {randomCancelTimer.ElapsedMilliseconds} milliseconds.");
        }
    }
}
