using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            const int maxQueued = 3;
            const int taskNumber = 10;

            var limitedQueue = new LimitedQueue<int>(maxQueued);
            var tasks = new Task[taskNumber];

            for(int i = 0; i < 10; i++)
            {
                int tastkId = i;

                tasks[i] = Task.Run(async () =>
                {
                    
                    var randomNumber = random.Next(1, 1000);

                    await Task.Delay(random.Next(1000, 3000));
                    Console.WriteLine($"Task {tastkId} begins and waits for Enque.");
                    limitedQueue.Enque(randomNumber);
                    Console.WriteLine($"Task {tastkId} added {randomNumber} To Queue.");
                    await Task.Delay(random.Next(1000, 2000));
                    Console.WriteLine($"Task {tastkId} continues and tries to Deque.");
                    Console.WriteLine($"Task {tastkId} removed {limitedQueue.Deque()} from queue.");
                });
            } 

            Task.WaitAll(tasks);

            Console.WriteLine();
            Console.WriteLine("All tasks finished. No DeadLock detected.");
        }
    }
}
