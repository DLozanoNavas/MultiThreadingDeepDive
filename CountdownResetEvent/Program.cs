// - CountdownEvent 

static class Program
{
    private static CountdownEvent _countdownEvent = new(5);
    
    static void Main(string[] args)
    {
        Task.Factory.StartNew(WorkerThread);
        Task.Factory.StartNew(WorkerThread);
        Task.Factory.StartNew(WorkerThread);
        Task.Factory.StartNew(WorkerThread);
        Task.Factory.StartNew(WorkerThread);
        _countdownEvent.Wait(); // Will need to be called 5 times before allowing to continue.
        Console.WriteLine("Signal have been called 5 times");
    }
    
    static void WorkerThread()
    {
        Task.Delay(1000);
        
        Console.WriteLine($"Task {Task.CurrentId} is calling signal");
        _countdownEvent.Signal();
        Console.WriteLine($"Task {Task.CurrentId} finally ended");
    }
}