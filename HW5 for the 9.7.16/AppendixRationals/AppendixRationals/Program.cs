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

            Console.WriteLine((rat1 + rat2).ToString());
            Console.WriteLine((rat1 * rat3).ToString());
            Console.WriteLine(rat3.Equals(rat1));
            Console.WriteLine(rat3.Equals(rat2));
            Console.WriteLine((rat3).ToString());
            rat3.Reduce();
            Console.WriteLine((rat3).ToString());
            rat1.Reduce();
        }
    }
}
