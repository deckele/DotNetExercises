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
            List<string> nameList = ReadNames("NamesForExercise.txt");
            foreach (var name in nameList)
            {
                Console.WriteLine(name);
            }
        }

        public static List<string> ReadNames(string path)
        {
            var nameList = new List<string>();
            var reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                nameList.Add(reader.ReadLine());
            }
            reader.Close();
            return nameList;
        }
    }
}
