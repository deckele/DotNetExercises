using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    internal class LimitedQueue<T>
    {
        private readonly Queue<T> _queue;
        private readonly SemaphoreSlim _semaphore;
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        public LimitedQueue(int maxQueued)
        {
            _queue = new Queue<T>();
            _semaphore = new SemaphoreSlim(maxQueued);
        }

        public void Enque(T item)
        {
            _semaphore.Wait();

            _lock.TryEnterWriteLock(-1);

            try
            {
                _queue.Enqueue(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public T Deque()
        {
            T item;

            _lock.TryEnterWriteLock(-1);

            _semaphore.Release();

            try
            {
                item = _queue.Dequeue();
            }
            finally
            {
                _lock.ExitWriteLock();
            }

            _lock.TryEnterReadLock(-1);

            try
            {
                return item;
            }
            finally
            {
               _lock.ExitReadLock(); 
            }
        }
    }
}
