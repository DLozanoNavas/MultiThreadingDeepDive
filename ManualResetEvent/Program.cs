// - ManualResetEvent 
//   - Similar to AutoResetEvent, but it does not automatically close after a thread steps through it.
//   - It releases all waiting threads.
class Program
{
    private static readonly ManualResetEvent EventWaitHandle = new(false);

    static void Main(string[] args)
    {
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        
        Thread.Sleep(1000);

        Console.WriteLine("Press a key again. Threads won´t block");
        Console.ReadKey();
        
        EventWaitHandle.Set(); // Signal the event.
        Thread.Sleep(1000);

        Console.WriteLine("Press a key again. Threads will block");
        Console.ReadKey();
        EventWaitHandle.Reset();
        
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Task.Factory.StartNew(CallWaitOne);
        Thread.Sleep(1000);

        Console.WriteLine("Press a key again. Threads will release");
        Console.ReadKey();
        EventWaitHandle.Set(); // Signal the event.

        Console.ReadLine();

    }

    static void CallWaitOne()
    {
        Console.WriteLine($"Task {Task.CurrentId} Waiting for signal");
        EventWaitHandle.WaitOne();
        Console.WriteLine($"Task {Task.CurrentId} finally ended");

    }
}