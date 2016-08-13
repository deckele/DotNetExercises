using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jobs
{
    public static class NativeJob
    {
        [DllImport("kernel32")]
        public static extern IntPtr CreateJobObject(IntPtr sa, string name);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr h);

        [DllImport("kernel32")]
        public static extern bool TerminateJobObject(IntPtr hjob, uint code);
    }

    public class Job : IDisposable
    {
        private readonly IntPtr _hJob;
        private readonly List<Process> _processes;
        private readonly long _sizeInByte;

        public Job(string name, long sizeInByte)
        {
            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            _processes = new List<Process>();
            _sizeInByte = sizeInByte;
            if (_hJob == IntPtr.Zero)
            {
                throw new InvalidOperationException();
            }
            GC.AddMemoryPressure(_sizeInByte);
        }

        public Job()
            : this(null, 1)
        {
        }

        public Job(long sizeInByte)
            : this(null, sizeInByte)
        {
        }

        public Job(string name)
            : this(name, 1)
        {
        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            CheckIfDisposed();

            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
                throw new InvalidOperationException("Failed to add process to job.");
        }

        private void CheckIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Error: Object already disposed.");
            }
        }

        public void AddProcessToJob(int pid)
        {
            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }

        public void Kill()
        {
            NativeJob.TerminateJobObject(_hJob, 0);
        }

        private bool _disposed = false; //To detect redundant calls

        // Implementing the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Job()
        {
            GC.RemoveMemoryPressure(_sizeInByte);
            Console.WriteLine("Job was released.");
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                foreach (var process in _processes)
                {
                    process.Dispose();
                }
            }
            NativeJob.CloseHandle(_hJob);
            _disposed = true;
        }
    }
}
