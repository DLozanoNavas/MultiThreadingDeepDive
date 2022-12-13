Thread.CurrentThread.Name = "Main Thread";

var thread = new Thread(WriteUsingNewThread)
{
    Name = "Worker Thread" // Naming threads (handy for debugging.)
}; // Worker Thread
thread.Start();
thread.Join(); // Wait for the thread to finish.

Console.WriteLine("Application Finished.");

void WriteUsingNewThread()
{
    Console.WriteLine("Hello World printed using thread: {0}.", Thread.CurrentThread.Name);
    Thread.Sleep(5000); // Simulate a long running task.
}