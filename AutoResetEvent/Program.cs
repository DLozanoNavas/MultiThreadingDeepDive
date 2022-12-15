
// Signaling is used to notify a waiting thread that it can not continue until the current thread has finished its work.
// Signaling is used to synchronize shared resources among threads.


// We use three EventWaitHandle objects to implement signaling.
// - AutoResetEvent: 
//   - Used when threads need exclusive access to a resource.
//   - Only one thread can be granted access to the resource at a time.
//   - it automatically closes right after some thread steps through it.

// - A thread waits for a signal by calling the WaitOne method.
// - A thread sends a signal by calling the Set method.
// - Calling the Set method signals the event and releases the waiting thread.
// - If multiple threads call WaitOnw, a queue is created and the threads are released in the order in which they were called.
// - If Set is called when no thread is waiting, the handle stays open indefinitely.



class Program
{
    //static EventWaitHandle eventWaitHandle = new(false, EventResetMode.AutoReset, "EventWaitHandle");
    
    static AutoResetEvent eventWaitHandle = new (false);
    
    static void Main(string[] args)
    {
        Task.Factory.StartNew(WorkerThread);
        Thread.Sleep(2500);
        eventWaitHandle.Set(); // Signal the event.
    }

    static void WorkerThread()
    {
        Console.WriteLine("Waiting for signal");
        eventWaitHandle.WaitOne();
        Console.WriteLine("Signal received");
        
    }
}