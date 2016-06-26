using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2_HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int n;
            Console.WriteLine("What's your name?");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + "!");
            Console.WriteLine("Display your cool name how many times?");
            n= int.Parse(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<i; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(name);
                
            }
        }
    }
}
