// Threads share Heap Memory, even though they have isolated stack memory.
Thread.CurrentThread.Name = "Main Thread";

new Thread(PrintNumbers)
{
    Name = "Worker Thread" // Naming threads (handy for debugging.)
}.Start(); // Worker Thread

PrintNumbers();

void PrintNumbers(){
    for (var i = 0; i < 30; i++) // Each thread will have it's own copy of i.
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
    }
}