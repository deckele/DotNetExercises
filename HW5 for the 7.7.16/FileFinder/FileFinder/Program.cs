using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((args[0] == null) || (args[1] == null))
            {
                Console.WriteLine("Error: Invalid arguments.");
                return;
            }
            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine("Error: Directory doesn't exist.");
                return;
            }
        }
    }
}
