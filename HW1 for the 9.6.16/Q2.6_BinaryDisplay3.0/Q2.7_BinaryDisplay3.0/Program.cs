using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2._7_BinaryDisplay3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            bool num_check = false;
            Console.WriteLine("Input integer:");
            while (!num_check)
            {
                num_check = int.TryParse(Console.ReadLine(), out num);
                if (!num_check)
                {
                    Console.WriteLine("Error: Not a valid number. Please try again.");
                }
            }

            int bitCount = 0;
            int n = num;
            List<int> binar = new List<int>();
            while (n != 0)
            {
                if ((n & 1) != 0)
                {
                    binar.Add(1);
                    bitCount++;
                }
                else
                {
                    binar.Add(0);
                }
                n >>= 1;            
            }
            if (num == 0)
            {
                binar.Add(0);
            }

            binar.Reverse();
            Console.WriteLine("your number in binary is:");
            foreach(int i in binar)
            {
                Console.Write(i);
            }
            Console.WriteLine("\n\nThe number of 1's in your binary number is: {0}.\n", bitCount);            
        }
    }
}
