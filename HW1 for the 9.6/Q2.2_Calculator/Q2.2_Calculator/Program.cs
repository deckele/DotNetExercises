using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2._2_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = 0;
            char action='?';
            bool a_check = false;
            bool b_check = false;
            bool action_check = false;
            
            while (!a_check)
            {
                Console.WriteLine("Input first number");
                a_check = double.TryParse(Console.ReadLine(), out a);
                if (!a_check)
                {
                    Console.WriteLine("Error: not a number.");

                }
            }

            while (!action_check)
            {
                Console.WriteLine("Choose action: \n1. +\n2. -\n3. *\n4. /");
                action_check = char.TryParse(Console.ReadLine(), out action);
                if (action != '1' && action != '2' && action != '3' && action != '4' && action != '+' && action != '-' && action != '*' && action != '/')
                {
                    Console.WriteLine("Error: action not allowed.");
                    action_check = false;
                }
                else
                {
                    action_check = true;
                }
            }

            while (!b_check)
            {
                Console.WriteLine("Input second number");
                b_check = double.TryParse(Console.ReadLine(), out b);
                if (!b_check)
                {
                    Console.WriteLine("Error: not a number.");

                }
                if ((action == '4' || action == '/') && b == 0)
                {
                    Console.WriteLine("Error: devided by zero. World exploded. Try again.");
                    b_check = false;
                }
            }

            switch (action)
            {
                case '+':
                case '1':
                    Console.WriteLine("\nYour number is: {0}." , (a + b));
                    break;
                case '-':
                case '2':
                    Console.WriteLine("\nYour number is: {0}." , (a - b));
                    break;
                case '*':
                case '3':
                    Console.WriteLine("\nYour number is: {0}." , (a * b));
                    break;
                case '/':
                case '4':
                    Console.WriteLine("\nYour number is: {0}." , (a / b));
                    break;
            }

        }
    }
}
