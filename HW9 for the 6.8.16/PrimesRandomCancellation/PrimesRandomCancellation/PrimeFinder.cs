using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesRandomCancellation
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
            var randomNumber = new Random();
            var lockerObject = new object();

            var primeList = new ArrayList();

            Parallel.For(input1, input2, (number, state) =>
            {
                if (randomNumber.Next(10000000) == 0)
                {
                    state.Stop();
                }

                if (CheckPrime(number))
                {
                    lock (lockerObject)
                    {
                        primeList.Add(number);
                    }
                }
            });

            var primeArray = new int[primeList.Count];
            primeList.CopyTo(primeArray);
            return primeArray;
        }

        /// <summary>
        /// Checks if given argument is a prime number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool CheckPrime(int number)
        {
            if (number < 0)
            {
                return false;
            }

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

            for (var i = 3; (i*i) <= number; i += 2)
            {
                if ((number%i) == 0)
                {
                    return false;
                }
            }
            return number != 1;
        }
    }
}
