using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    class ProcessDisplayer
    {
        public IEnumerable<IGrouping<int, Process>> GetProcesses(int maxTreads)
        {
            var processes = from process in Process.GetProcesses()
                where process.Threads.Count <= maxTreads
                orderby process.Id
                group process by process.BasePriority into priorityGroups
                orderby priorityGroups.Key
                select priorityGroups;

            return processes;
        }
    }
}
