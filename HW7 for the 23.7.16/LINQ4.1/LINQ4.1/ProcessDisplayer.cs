using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ4._1
{
    internal class ProcessDisplayer
    {
        public IEnumerable<IGrouping<int, Process>> GetProcesses(int maxTreads)
        {
            var processesQuery = from process in Process.GetProcesses()
                where process.Threads.Count <= maxTreads
                orderby process.Id
                group process by process.BasePriority into priorityGroups
                orderby priorityGroups.Key
                select priorityGroups;

            return processesQuery;
        }

        public bool CanAccessTimeStart(Process process)
        {
            try
            {
                var startTime = process.StartTime;
                return true;
            }
            catch (Win32Exception)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
