using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    internal class SequentialBuilder
    {
        public void Build()
        {
            var project1 = Task.Factory.StartNew(() => { Console.WriteLine("Project 1 built."); Thread.Sleep(1000); });
            var project2 = project1.ContinueWith(previousProject => { Console.WriteLine("Project 2 built."); Thread.Sleep(1000); });
            var project3 = project2.ContinueWith(previousProject => { Console.WriteLine("Project 3 built."); Thread.Sleep(1000); });
            var project4 = project3.ContinueWith(previousProject => { Console.WriteLine("Project 4 built."); Thread.Sleep(1000); });
            var project5 = project4.ContinueWith(previousProject => { Console.WriteLine("Project 5 built."); Thread.Sleep(1000); });
            var project6 = project5.ContinueWith(previousProject => { Console.WriteLine("Project 6 built."); Thread.Sleep(1000); });
            var project7 = project6.ContinueWith(previousProject => { Console.WriteLine("Project 7 built."); Thread.Sleep(1000); });
            var project8 = project7.ContinueWith(previousProject => { Console.WriteLine("Project 8 built."); Thread.Sleep(1000); });

            Task.WaitAll(project8);
        }
    }
}
