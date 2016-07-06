using System;
using System.Collections.Generic;
using System.IO;

namespace FileFinder
{
    public class FileFinder
    {
        public List<string> SearchFiles(string searchPath, string searchQuarry)
        {
            searchQuarry = "*" + searchQuarry + "*";
            List<string> fileList = new List<string>();

            fileList.AddRange(Directory.GetFiles(searchPath,searchQuarry));
            
            var subDirectories = Directory.GetDirectories(searchPath);
            foreach (var path in subDirectories)
            {
                fileList.AddRange(SearchFiles(path, searchQuarry));
            }
            return fileList;
        }
    }
}