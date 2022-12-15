using System.Diagnostics;

static class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopWatch = new();
        
        for (var i = 0; i < 100000; i++)
        {
            Console.WriteLine(i);
        }
        
        stopWatch.Stop();
        Console.WriteLine("For loop took: " + stopWatch.ElapsedMilliseconds + "ms");
        stopWatch.Restart();
        
        Console.WriteLine("---------------------------------");
        Parallel.For(0, 100000, Console.WriteLine);
        Console.WriteLine("Parallel.For took: " + stopWatch.ElapsedMilliseconds + "ms");
    }
}