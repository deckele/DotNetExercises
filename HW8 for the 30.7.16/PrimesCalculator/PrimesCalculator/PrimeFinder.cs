using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimesCalculator
{
    internal class PrimeFinder
    {
        /// <summary>
        /// Returns an integer array of all prime numbers between input 1 and input 2 of user.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="waitHandle"></param>
        /// <returns></returns>
        public static int[] CalcPrimes(int input1, int input2, WaitHandle waitHandle)
        {
            var primeList = new ArrayList();
            for (var i = Math.Min(input1, input2); i <= Math.Max(input1, input2); i++)
            {
                if (waitHandle.WaitOne(0))
                {
                    break;
                }

                if (PrimeFinder.CheckPrime(i))
                {
                    primeList.Add(i);
                }
            }
            var primeArray = new int[primeList.Count];
            primeList.CopyTo(primeArray);
            return primeArray;
        }

        /// <summary>
        /// Checks if given argument is a prime number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool CheckPrime(int number)
        {
            if ((number & 1) == 0)
            {
                if (number == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (var i = 3; (i * i) <= number; i += 2)
            {
                if ((number % i) == 0)
                {
                    return false;
                }
            }
            return number != 1;
        }
    }
}

