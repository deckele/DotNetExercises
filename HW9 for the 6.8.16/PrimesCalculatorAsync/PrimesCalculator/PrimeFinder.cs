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
        /// Returns an integer counting the number of prime numbers between input 1 and input 2 of user.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="waitHandle"></param>
        /// <returns></returns>
        public static int CountPrimes(int input1, int input2, WaitHandle waitHandle)
        {
            var primeList = new ArrayList();
            for (var i = Math.Min(input1, input2); i <= Math.Max(input1, input2); i++)
            {
                if (waitHandle != null)
                {
                    if (waitHandle.WaitOne(0))
                    {
                        break;
                    }
                }

                if (PrimeFinder.CheckPrime(i))
                {
                    primeList.Add(i);
                }
            }

            return primeList.Count;
        }

        /// <summary>
        /// Returns an integer counting the number of prime numbers between input 1 and input 2 of user (Asynchronous method).
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="waitHandle"></param>
        /// <returns></returns>
        public static async Task<int> CountPrimesAsync(int input1, int input2, WaitHandle waitHandle)
        {
            return await Task.Run(() => CountPrimes(input1, input2, waitHandle));
        }

        /// <summary>
        /// Checks if given argument is a prime number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool CheckPrime(int number)
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

