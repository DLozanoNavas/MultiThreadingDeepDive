
class Program
{
    static Mutex mutex = new(false, "Mutex");
    
    static void Main(string[] args)
    {
        for (var i = 0; i < 10; i++)
        {
            new Thread(AcquireMutex){Name = $"Thread {i}"}.Start();
        }
    }

    static void AcquireMutex()
    {
        mutex.WaitOne(); // Wait until it is safe to enter.
        Console.WriteLine($"{Thread.CurrentThread.Name} has entered the protected area");
        Thread.Sleep(1000);
        Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the protected area");
        mutex.ReleaseMutex(); // Release the Mutex.
    }
}