
class Program
{
    static Mutex mutex = new(false, "Mutex");
    
    static void Main(string[] args)
    {
        //for (var i = 0; i < 10; i++)
        //{
        //    new Thread(AcquireMutex) { Name = $"Thread {i}" }.Start();
        //}

        for (var i = 0; i < 10; i++)
        {
            new Thread(AcquireMutexV2) {Name = $"Thread {i}"}.Start();
        }
        Console.ReadLine();
    }

    static void AcquireMutexV2()
    {
        try
        {
            var exitContext = true;
            if (mutex.WaitOne(1000, exitContext))
            {
                Console.WriteLine($"[V2] Mutex acquired by thread {Thread.CurrentThread.Name}");
                Thread.Sleep(500);
                Console.WriteLine($"[V2] Mutex released by thread {Thread.CurrentThread.Name}");
                mutex.ReleaseMutex();
            }
            else
            {
                Console.WriteLine($"Mutex not acquired by thread {Thread.CurrentThread.Name}. {(exitContext ? "Exiting context" : "Keeping Context")}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message} by thread {Thread.CurrentThread.Name}");
        }
  
    }
    
    static void AcquireMutex()
    {
        mutex.WaitOne(); // Wait until it is safe to enter.
        Console.WriteLine($"[V1] {Thread.CurrentThread.Name} has entered the protected area");
        Thread.Sleep(1000);
        Console.WriteLine($"[V1] {Thread.CurrentThread.Name} is leaving the protected area");
        mutex.ReleaseMutex(); // Release the Mutex.
    }
}