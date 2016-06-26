using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prime calculator!\nPlease input first number for your prime number range:");
            int input1 = UserInput();
            Console.WriteLine("Now please input second number for your prime number range:");
            int input2 = UserInput();
            int[] primeArray = PrimeFinder.CalcPrimes(input1, input2);
            if (primeArray.Length == 0)
            {
                Console.WriteLine("No prime numbers in range. Sorry :'(");
            }
            else
            {
                Console.WriteLine("The prime numbers within your given range are:\n");
                foreach (int prime in primeArray)
                {
                    Console.Write(prime + ", ");
                }
            }            
        }

        /// <summary>
        /// Checks if user input is a valid integer.
        /// </summary>
        /// <returns></returns>
        static int UserInput()
        {
            bool inputCheck = false; 
            int input=0;

            while (!inputCheck)
            {
                inputCheck = int.TryParse(Console.ReadLine(), out input);
                if (!inputCheck)
                {
                    Console.WriteLine("Not a valid number. Please try again.");
                }
            }
            return input;
        }
    }    

    class PrimeFinder
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
            for (int i = Math.Min(input1,input2); i <= Math.Max(input1,input2); i++)
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
