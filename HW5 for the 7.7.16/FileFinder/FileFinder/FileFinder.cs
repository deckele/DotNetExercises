using System;
using System.Collections.Generic;
using System.IO;

namespace FileFinder
{
    public class FileFinder
    {
        public List<string> SearchFiles(string searchPath, string searchQuarry)
        {
            //Turns search into a wildcard search
            searchQuarry = "*" + searchQuarry + "*";
            List<string> fileList = new List<string>();

            fileList.AddRange(Directory.GetFiles(searchPath,searchQuarry));
            
            var subDirectories = Directory.GetDirectories(searchPath);
            foreach (var path in subDirectories)
            {
                //recursion - method calling itself, adding all subdirectories to fileList collection.
                fileList.AddRange(SearchFiles(path, searchQuarry));
            }
            return fileList;
        }
    }
}