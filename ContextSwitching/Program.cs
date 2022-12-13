// Is up to the OS to switch execution context depending on the resources available.
Thread.CurrentThread.Name = "Main Thread";

var thread = new Thread(WriteUsingNewThread)
{
    Name = "Worker Thread" // Naming threads (handy for debugging.)
}; // Worker Thread

thread.Start();

WriteUsingMainThread(); // Main thread

static void WriteUsingMainThread()
{
    for (var i = 0; i < 1000; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
    }
}

static void WriteUsingNewThread()
{
    // Each thread has its own memory stack,
    // and a separate copy of local variables is created on each thread memory stack.
    for (var i = 0; i < 1000; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
    }
}