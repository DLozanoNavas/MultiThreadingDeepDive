// SemaphoreSlim is a class introduced in .NET Framework 4.0 that provides a semaphore.
// - It is a lightweight version of the Semaphore class.
// - It is a value type and does not require the use of the using statement.
// - It is a good choice for scenarios where the number of threads that can access a resource is limited.

class Program
{
    static readonly SemaphoreSlim SemaphoreSlim = new(3, 3);
    
    static void Main(string[] args)
    {
        for (var i = 0; i < 10; i++)
        {
            new Thread(AcquireSemaphoreSlim) { Name = $"Thread {i}" }.Start();
        }
    }
    
    static void AcquireSemaphoreSlim()
    {
        SemaphoreSlim.Wait();
        Console.WriteLine($"[V1] {Thread.CurrentThread.Name} has entered the protected area");
        Thread.Sleep(1000);
        Console.WriteLine($"[V1] {Thread.CurrentThread.Name} is leaving the protected area");
        SemaphoreSlim.Release();
    }
}