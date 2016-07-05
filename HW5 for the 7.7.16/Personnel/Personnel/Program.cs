using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameReader = new NameReader("NamesForExercise.txt");
            List<string> nameList = nameReader.ReadNames();

            Console.WriteLine("List of names:");
            Console.WriteLine();
            foreach (var name in nameList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
