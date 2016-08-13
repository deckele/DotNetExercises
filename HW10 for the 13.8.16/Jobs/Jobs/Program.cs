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
            //Part A of exercise.
            var job = new Job("MyProcesses", 1);
            Process.Start("notepad");
            Process.Start("mspaint");
            job.AddProcessToJob(Process.GetProcessesByName("notepad")[0]);
            job.AddProcessToJob(Process.GetProcessesByName("mspaint")[0]);

            Console.WriteLine("Press <Enter> key to kill processes...");
            Console.ReadLine();
            job.Kill();

            //Part B of exercise.
            Console.WriteLine("Adding 20 Job objects with 0MB additional memory:");
            var jobs = new List<Job>();
            for (int i = 0; i < 20; i++)
            {
                jobs.Add(new Job(1));
                Console.WriteLine($"Job {i} was created.");
            }
            jobs.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Adding 20 Job objects with 10MB additional memory:");
            for (int i = 0; i < 20; i++)
            {
                jobs.Add(new Job(10485760));
                Console.WriteLine($"Job {i} was created.");
            }

            Console.WriteLine();
            Console.WriteLine("App needed to free some memory to proceed, calling GC.");
        }
    }
}
