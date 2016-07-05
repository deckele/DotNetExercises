using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            else if (!Directory.Exists(args[0]))
            {
                Console.WriteLine("Error: Directory doesn't exist.");
                return;
            }

            var fileFinder = new FileFinder();
            var fileList = fileFinder.SearchFiles(args[0], args[1]);

            Console.WriteLine("File Names that match:");
            Console.WriteLine();
            foreach (var fileName in fileList)
            {
                Console.WriteLine(fileName);
            }
        }
    }
}