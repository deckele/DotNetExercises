using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    internal class ThreadCounter
    {
        private int _threadCount;

        public int Count()
        {
            var threadsInProcessList = from process in Process.GetProcesses()
                select process.Threads.Count;

            foreach (var threadsInProcess in threadsInProcessList)
            {
                _threadCount += threadsInProcess;
            }

            return _threadCount;
        }
    }
}
