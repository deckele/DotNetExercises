using System;
using System.Collections.Generic;
using System.IO;

namespace FileFinder
{
    public class FileFinder
    {
        public List<string> SearchFiles(string searchPath, string searchQuarry)
        {
            List<string> fileList = new List<string>();

            fileList.AddRange(Directory.GetFiles(searchPath,searchQuarry));

            var subDirectories = Directory.GetDirectories(searchPath);
            foreach (var path in subDirectories)
            {
                SearchFiles(path, searchQuarry);
            }
            return fileList;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}