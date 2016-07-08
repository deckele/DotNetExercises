using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendixRationals
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational rat1 = new Rational(1, 2);
            Rational rat2 = new Rational(20, 60);
            Rational rat3 = new Rational(50, 100);
            Rational rat4 = new Rational(200, 45);

            Console.WriteLine($"int conversion value of {rat2.ToString()} is: {(int)rat2}");
            Console.WriteLine($"int conversion value of {rat4.ToString()} is: {(int)rat4}");
            Console.WriteLine($"double conversion value of {rat2.ToString()} is: {(double)rat2}");
            Console.WriteLine($"double conversion value of {rat4.ToString()} is: {(double)rat4}");
            Console.WriteLine();

            Console.WriteLine($"{rat1.ToString()}+{rat2.ToString()}={(rat1 + rat2).ToString()}");
            Console.WriteLine($"{rat1.ToString()}-{rat2.ToString()}={(rat1 - rat2).ToString()}");
            Console.WriteLine($"{rat1.ToString()}*{rat3.ToString()}={(rat1 * rat3).ToString()}");
            Console.WriteLine($"{rat2.ToString()}:{rat1.ToString()}={(rat2 / rat1).ToString()}");
            Console.WriteLine();

            Console.WriteLine($"Does {rat3.ToString()} = {rat1.ToString()}? {rat3.Equals(rat1)}.");
            Console.WriteLine($"Does {rat3.ToString()} = {rat2.ToString()}? {rat3.Equals(rat2)}.");
            Console.WriteLine();

            Console.WriteLine($"Reducing {(rat3).ToString()}:");
            rat3.Reduce();
            Console.WriteLine((rat3).ToString());
            Console.WriteLine($"Reducing {(rat1).ToString()}:");
            rat1.Reduce();
            Console.WriteLine((rat1).ToString());
            Console.WriteLine($"Reducing {(rat4).ToString()}:");
            rat4.Reduce();
            Console.WriteLine((rat4).ToString());
        }
    }
}
