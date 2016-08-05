using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2._7_BinaryDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            int counter = 0;
            int index = 0;
            int bin = 1;
            bool num_check=false;
            Console.WriteLine("Input integer:");
            while (!num_check)
            {
                num_check = int.TryParse(Console.ReadLine(), out num);
                if (!num_check)
                {
                    Console.WriteLine("Error: Not a valid number. Please try again.");
                }
            }

            int x = num;
            for (int binar = 1; binar <= x; binar *= 2)
            {
                counter++;
                bin *= 2;
            }

            int[] binary = new int[counter];
            for(int binar=bin; x>=1; binar /= 2)
            {
                if (binar > x)
                {
                    counter--;
                    continue;
                }
                else
                {
                    binary[counter] = 1;
                    x -= (binar);
                    counter--;
                }
            }
            Array.Reverse(binary);
            Console.WriteLine("Your nuber in binary code is:");
            index = binary.Length;            
            foreach (int a in binary)
            {
                Console.Write(a);
            }
            Console.WriteLine("");

            int count_1 = 0;
            int j= 0;
            while (j <= binary.Length)
            {
                if ((num & (1 << index)) != 0)
                {
                    count_1++;
                }
                j++;
                index--;
            }
            Console.WriteLine("Number of 1's in your binary number: " + count_1);
        }
    }
}
