using System;
using System.Collections.Generic;
using System.IO;

namespace FileFinder
{
    public class FileFinder
    {
        public FileFinder(string searchPath, string searchQuarry)
        {
            SearchPath = searchPath;
            SearchQuarry = searchQuarry;
        }

        public string SearchPath { get; private set; }
        public string SearchQuarry { get; private set; }

        public List<string> Search()
        {
            
            throw new Exception();
        }
    }
}