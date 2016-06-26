using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            bool exit=false;
            while (!exit)
            {
                Console.WriteLine("\nPlease write a sentance.");
                string str = Console.ReadLine();
                str = str.Trim();
                if (str == "")
                {
                    Console.WriteLine("No input. Buy!");
                    exit = true;
                    break;
                }
                string[] str_array = str.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine("Number of words in your string is {0}.", str_array.Length);
                Array.Reverse(str_array);
                Console.WriteLine("Your string reversed reads:");
                foreach (string i in str_array)
                    {
                        Console.Write(i + " ");
                    }
                Array.Sort(str_array);
                Console.WriteLine("\nYour sorted string reads:");
                foreach (string i in str_array)
                    {
                        Console.Write(i + " ");
                    }
                Console.WriteLine();                
            }
        }
    }
}
