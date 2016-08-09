using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    internal static class CustomAwaitersExtensions
    {
        public static TaskAwaiter GetAwaiter(this int milliseconds)
        {
            return Task.Delay(milliseconds).GetAwaiter();
        }

        public static TaskAwaiter<int> GetAwaiter(this Process process)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();
            process.EnableRaisingEvents = true;
            process.Exited += (obj, args) => taskCompletionSource.TrySetResult(process.ExitCode);

            if (process.HasExited)
            {
                taskCompletionSource.TrySetResult(process.ExitCode);
            }

            return taskCompletionSource.Task.GetAwaiter();
        }
    }
}
