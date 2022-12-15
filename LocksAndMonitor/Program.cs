// Locks limit the number of threads that can perform any kind of activity
// on a particular resource at any given time.

// There are two main types of locks:
// 1. Exclusive locks (also known as mutual exclusion locks or mutexes)
// 2. Non-Exclusive locks (also known as reader-writer locks)

// Exclusive locks:
// - Only one thread can hold the lock at any given time.
// - The thread that holds the lock can release it.
// - Other threads must wait until the lock is released.
// - Exclusive locks are also known as mutual exclusion locks or mutexes.
// - Exclusive locks are used to protect data that must be accessed by only one thread at a time.
// - Alternatively to use lock keyword, is to use Monitor.Enter/Exit .

// Non-Exclusive locks:
// - Multiple threads can hold the lock at the same time.
// - Semaphore is a non-exclusive lock.
// - SemaphoreSlim is a non-exclusive lock.
// - Reader/Writer lock is a non-exclusive lock.
// - Non-Exclusive locks allow multiple threads to access a resource at the same time.
// - Semaphores with a count of 1 are almost equivalent to exclusive locks.

// Signaling constructs:
// - Threads pause execution until they receive a signal from another thread.
// - There are two types of signaling constructs: EventWaitHandle and Monitor Wait/Pulse methods (Monitor.Wait, Monitor.Pulse, Monitor.PulseAll).
// - Threads can signal each other using events, AutoResetEvent, ManualResetEvent, CountdownEvent, SemaphoreSlim, and Barrier.

// Non-blocking synchronization:
// - Non-blocking synchronization is a technique that allows threads to access a resource without waiting for a lock.
// - Non-blocking synchronization is also known as lock-free synchronization.
// - Non-blocking synchronization protect access to a common field or object by using atomic operations.
// - Thread.MemoryBarrier() is a method that forces the processor to flush the cache and read the data from the main memory.
// - Thread.VolatileRead() is a method that forces the processor to read the data from the main memory.
// - Thread.VolatileWrite() is a method that forces the processor to write the data to the main memory.
// - Interlocked class is a class that provides atomic operations on variables.
// - Volatile keyword is a keyword that indicates that a field might be modified by multiple threads that are executing at the same time.

using LocksAndMonitor;

var account = new Account(20000);

// Create 10 threads that will withdraw money from the account.
// Each thread will withdraw a random amount of money.
// The account balance will be displayed after each withdrawal.

var tasks = new List<Task>();

for (var i = 0; i < 100; i++)
{
    tasks.Add(Task.Factory.StartNew(account.RandomWithdrawal));
}

Console.ReadLine();