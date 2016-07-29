using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <returns></returns>
        public static int[] CalcPrimes(int input1, int input2)
        {
            ArrayList primeList = new ArrayList();
            for (int i = Math.Min(input1, input2); i <= Math.Max(input1, input2); i++)
            {
                if (PrimeFinder.CheckPrime(i))
                {
                    primeList.Add(i);
                }
            }
            int[] primeArray = new int[primeList.Count];
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

            for (int i = 3; (i * i) <= number; i += 2)
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

