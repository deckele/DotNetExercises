using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2._7_DollarStairs
{
    class Program
    {        
        static void Main(string[] args)
        {
            int stairs = 0;
            bool stairs_check = false;

            Console.WriteLine("How many dollar stairs do you want? (Input number)\n");
            while (!stairs_check)
            {
                stairs_check = int.TryParse(Console.ReadLine(), out stairs);
                if (!stairs_check)
                {
                    Console.WriteLine("Error, invalid number. Please try again.\n");
                }
            }
                        
            for (int i = 0; i<stairs; i++)
            {
                Console.WriteLine();
                for (int j = 0; j<=i; j++)
                {
                    Console.Write("$ ");
                }                
            }
        }
    }
}
