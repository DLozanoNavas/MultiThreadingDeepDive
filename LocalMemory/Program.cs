new Thread(PrintNumbers)
{
    Name = "Worker Thread" // Naming threads (handy for debugging.)
}.Start(); // Worker Thread

Thread.CurrentThread.Name = "Main Thread";

PrintNumbers();

void PrintNumbers(){
    for (var i = 0; i < 30; i++) // Each thread will have it's own copy of i.
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
    }
}