class Program
{
    private static readonly EventWaitHandle First = new(false, EventResetMode.AutoReset, "EventWaitHandle");
    private static readonly EventWaitHandle Second = new(false, EventResetMode.AutoReset, "EventWaitHandle");
    private static readonly object ThisLock = new();
    static string _value = string.Empty;
    static void Main(string[] args)
    {
        Task.Factory.StartNew(WorkerThread);
        Console.WriteLine("Main Thread waiting for signal");
        First.WaitOne();
        Console.WriteLine("Main Thread received signal");
        lock (ThisLock)
        {
            _value = "Hello from Main Thread";
            Console.WriteLine("Value: " + _value);
        }
        Thread.Sleep(1000);
        Second.Set(); // Signal the event.
    }

    static void WorkerThread()
    {
        Thread.Sleep(2500);
        lock (ThisLock)
        {
            _value = "Hello from Worker Thread";
            Console.WriteLine("Value: " + _value);

        }

        Console.WriteLine("Main Thread Released by Worker Thread");
        First.Set(); // Release the Main Thread.
        
        Console.WriteLine("Worker Thread is waiting for signal");
        Second.WaitOne();
        Console.WriteLine("Worker Thread Released by Main Thread");

    }
}