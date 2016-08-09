using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class Program
    {
        static void Main(string[] args)
        {
            var task1= Task.Run(async () =>
            {
                Console.WriteLine("Started awaiting on integer using 2000 milliseconds. " + DateTime.Now);
                await 2000;
                Console.WriteLine("Task completed - awaiting on integer. " + DateTime.Now);
            });

            Task.WaitAll(task1);

            var task2 = Task.Run(async () =>
            {
                Console.WriteLine("Started awaiting on process until closed." + DateTime.Now);
                var process = Process.Start("mspaint");
                if (process != null)
                {
                    await process;
                }
                Console.WriteLine("Process closed. " + DateTime.Now);
            });

            Task.WaitAll(task1, task2);
        }
    }
}
