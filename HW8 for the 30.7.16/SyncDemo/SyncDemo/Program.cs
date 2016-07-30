using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var mutex = new Mutex(false, "SyncFileMutex");

            for (var i = 0; i < 10000; i++)
            {
                mutex.WaitOne();
                File.AppendAllText(@"C:\Temp\data.txt", Process.GetCurrentProcess().Id.ToString() + Environment.NewLine);
                mutex.ReleaseMutex();
            }
        }
    }
}
