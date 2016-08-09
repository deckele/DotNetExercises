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
            var project1 = new Task(() => { Console.WriteLine("Project 1 built."); Thread.Sleep(1000); });
            var project2 = new Task(() => { Console.WriteLine("Project 2 built."); Thread.Sleep(1000); });
            var project3 = new Task(() => { Console.WriteLine("Project 3 built."); Thread.Sleep(1000); });
            var project4 = project1.ContinueWith(previousProject => { Console.WriteLine("Project 4 built."); Thread.Sleep(1000); });
            var project5 = Task.Factory.ContinueWhenAll(new[] { project1, project2, project3 },
                previousProjects => { Console.WriteLine("Project 5 built."); Thread.Sleep(1000); });
            var project6 = Task.Factory.ContinueWhenAll(new[] { project3, project4 },
                previousProjects => { Console.WriteLine("Project 6 built."); Thread.Sleep(1000); });
            var project7 = Task.Factory.ContinueWhenAll(new[] { project5, project6 },
                previousProjects => { Console.WriteLine("Project 7 built."); Thread.Sleep(1000); });
            var project8 = project5.ContinueWith(previousProject => { Console.WriteLine("Project 8 built."); Thread.Sleep(1000); });

            project1.Start();
            project2.Start();
            project3.Start();

            Task.WaitAll(project7, project8);
        }
    }
}
