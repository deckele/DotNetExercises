using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2._7_BinaryDisplay2._0
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

            int counter = 0;
            List<int> binar = new List<int>();
            for (int i = 0; i < 32; i++)
            {
                if ((num & (1<<i)) != 0)
                {
                    binar.Add(1);
                    counter++;
                }
                else
                {
                    binar.Add(0);
                }
            }

            binar.Reverse();
            if (num >= 0)
            {
                while(binar[0] == 0)
                {
                    binar.Remove(0);                    
                }
            }
            
            Console.WriteLine("Your number converted to binary is:\n");
            foreach (int a in binar)
            {
                Console.Write(a);
            }
            Console.WriteLine("\n\nNumber of 1's in your binary number: {0}. \n", counter);            
        }
    }
}
