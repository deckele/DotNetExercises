using System.Collections.Generic;
using System.IO;

namespace Personnel
{
    public class NameReader
    {
        public NameReader(string path)
        {
            NamePath = path;
        }

        public string NamePath { get; private set; }

        public List<string> ReadNames()
        {
            var nameList = new List<string>();
            if (File.Exists(NamePath))
            {
                var reader = new StreamReader(NamePath);

                while (!reader.EndOfStream)
                {
                    nameList.Add(reader.ReadLine());
                }
                reader.Close();
            }
            return nameList;
        }
    }
}