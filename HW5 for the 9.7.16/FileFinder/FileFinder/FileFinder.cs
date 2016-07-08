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
            var files = Directory.GetFiles(searchPath);
            foreach (var fileName in files)
            {
                var shortFileName = Path.GetFileName(fileName);
                if (shortFileName.Contains(searchQuarry))
                {
                    fileList.Add(shortFileName);
                }
            }

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