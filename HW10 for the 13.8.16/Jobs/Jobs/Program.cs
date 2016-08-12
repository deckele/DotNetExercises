using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            var job = new Job("MyProcesses", 1);
            Process.Start("notepad");
            Process.Start("mspaint");
            job.AddProcessToJob(Process.GetProcessesByName("notepad")[0]);
            job.AddProcessToJob(Process.GetProcessesByName("mspaint")[0]);

            Console.WriteLine("Press Enter key to kill processes...");
            Console.ReadLine();
            job.Kill();

            for (int i = 0; i < 20; i++)
            {
                new Job(10240);
            }


        }
    }
}
