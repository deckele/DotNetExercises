using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2._4_Quad
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)   //checking if length of args is valid.
            {
                Console.WriteLine("Error: Cannot determine x. Please start again and enter exactly three parameters from console.");
                return;
            }
            else if (args.Length == 1)
            {
                args[1] = "0";
                args[2] = "0";
            }
            else if (args.Length == 2)
            {
                args[2] = "0";
            }
            else if(args.Length > 3)
            {
                Console.WriteLine("Error: Too many parameters. Please start again and enter only three parameters from console.");
                return;
            }

            double[] double_args = new double[3]; //checking if all parameters are doubles
            for (int i=0; i<args.Length; i++) {
                if (double.TryParse(args[i], out double_args[i])) ;
                else
                {
                    Console.WriteLine("Error: Didn't enter valid numbers. Please try again.");
                    return;
                }            
            }

            double a = double_args[0];
            double b = double_args[1];
            double c = double_args[2];
            if ((a == 0) && (b!=0))                 //If a == 0 the equation is linear. 
            {
                Console.WriteLine("The solution of your linear equasion: {0}X^2 + {1}X + {2} is: \nX = {3}",
                    a, b, c, -(c / b));
            }
            else if ((a == 0) && (b == 0))
            {
                Console.WriteLine("There are no X's in your equation: {0}X^2 + {1}X + {2}.",
                    a, b, c);
            }
            else if (((b*b)-(4*a*c))<0)             //No solution case for quadratic equation.
            {
                Console.WriteLine("There are no solutions for X in your quadratic equation: {0}X^2 + {1}X + {2}.",
                    a, b, c);
            }
            else if (((b * b) - (4 * a * c)) == 0)  //One solution case for quadratic equation.
            {
                Console.WriteLine("The solution for your quadratic equasion: {0}X^2 + {1}X + {2} is: \nX = {3} (no second solution)",
                    a, b, c, ((-b) / (2 * a)));
            }
            else                                    //Two solution case for quadratic equation.
            {
                Console.WriteLine("The solutions for your quadratic equasion: {0}X^2 + {1}X + {2} are: \nX1 = {3} \nX2 = {4}", 
                    a, b, c, (-b + Math.Sqrt((b*b)-(4*a*c)))/(2*a), (-b - Math.Sqrt((b * b) - (4 * a * c))) / (2 * a));
            }            
        }         
    }
}
