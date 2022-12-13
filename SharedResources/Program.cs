Thread.CurrentThread.Name = "Main Thread";
bool isCompleted = false;
object lockCompleted = new object();

var thread = new Thread(WriteHelloWorld)
{
    Name = "Worker Thread" // Naming threads (handy for debugging.)
}; // Worker Thread
thread.Start();
WriteHelloWorld();

void WriteHelloWorld()
{
    lock (lockCompleted)
    {
        if (isCompleted) return;

        Console.WriteLine($"Hello world using thread: {Thread.CurrentThread.Name}.");
        
        isCompleted = true;
    }
}