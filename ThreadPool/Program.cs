// Every Thread has an overhead of a few milliseconds and ~ 1MB of memory.
// Multiple active threads can throttle the OS.
Thread.CurrentThread.Name = "Main Thread";

Console.WriteLine($"{Thread.CurrentThread.Name} thread is ThreadPool thread?: {Thread.CurrentThread.IsThreadPoolThread}.");

var employee = new Employee
{
    Name = "Daniel Lozano",
    Company = "Fenix Alliance",
};

var processorCount = Environment.ProcessorCount;
Console.WriteLine($"PC has {processorCount} processors.");

ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);

Console.WriteLine($"[Before] Min Worker Threads: {minWorkerThreads}.");
Console.WriteLine($"[Before] Min Completion Port Threads: {minCompletionPortThreads}.");
Console.WriteLine($"[Before] Max Worker Threads: {maxWorkerThreads}.");
Console.WriteLine($"[Before] Max Completion Port Threads: {maxCompletionPortThreads}.");

ThreadPool.SetMaxThreads(processorCount * 2, processorCount * 2);
ThreadPool.SetMinThreads(processorCount * 2, processorCount * 2);

ThreadPool.GetMinThreads(out  minWorkerThreads, out  minCompletionPortThreads);
ThreadPool.GetMaxThreads(out  maxWorkerThreads, out  maxCompletionPortThreads);

Console.WriteLine($"[After] Min Worker Threads: {minWorkerThreads}.");
Console.WriteLine($"[After] Min Completion Port Threads: {minCompletionPortThreads}.");
Console.WriteLine($"[After] Max Worker Threads: {maxWorkerThreads}.");
Console.WriteLine($"[After] Max Completion Port Threads: {maxCompletionPortThreads}.");

ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeName), employee);

Console.ReadLine();

void DisplayEmployeeName(object? emp)
{
    Console.WriteLine($"{Thread.CurrentThread.Name} thread is ThreadPool thread?: {Thread.CurrentThread.IsThreadPoolThread}.");
    Console.WriteLine($"Employee name: {((Employee)emp!).Name}");
}

class Employee
{
    public string? Name { get; set; }
    public string? Company { get; set; }
}