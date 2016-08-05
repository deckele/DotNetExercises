using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2._3_GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int secret = new Random().Next(1, 101);
            int guess = 0;
            int counter = 0;
            bool check_guess=false;
            bool check_correct = false;
            Console.WriteLine("Can you guess my secret number (1-100) in less than 8 attempts?");
            while (!check_correct)
            {
                while (!check_guess)
                {
                    check_guess = int.TryParse(Console.ReadLine(), out guess);
                    if (check_guess && guess >= 1 && guess <= 100)
                    {
                        check_guess = true;
                    }
                    else
                    {
                        check_guess = false;
                        Console.WriteLine("Error: not a valid guess. Try again!");
                    }
                }
                counter++;
                if (guess == secret)
                {
                    check_correct = true;
                }
                else if (guess < secret)
                {
                    Console.WriteLine("Too low, Try again!");
                }
                else if (guess > secret)
                {
                    Console.WriteLine("Too high, Try again!");
                }
                check_guess = false;
            }
            if (counter > 7)
            {
                Console.WriteLine("\nYou guessed it! \nNo. of attempts: {0}. \nyou failed to guess in under 8 attempts :( \nGame over", counter);
            }
            else
            {
                Console.WriteLine("\nYou guessed it! \nNo. of attempts: {0}. \nWell Done!!! :) \nGame over", counter);
            }
        }
    }
}
