object firstLock = new object();
object secondLock = new object();

new Thread(FirstMethod) { Name = "First Thread" }.Start();
new Thread(SecondMethod) { Name = "Second Thread" }.Start();

Console.ReadLine();

// This method will be called by the first thread.
void FirstMethod()
{
    lock (firstLock)
    {
        Console.WriteLine("First thread acquired first lock");
        Thread.Sleep(1000);
        lock (secondLock)
        {
            Console.WriteLine("First thread acquired second lock");
        }
    }
}

// This method will be called by the second thread.
void SecondMethod()
{
    lock (secondLock)
    {
        Console.WriteLine("Second thread acquired second lock");
        Thread.Sleep(1000);
        lock (firstLock)
        {
            Console.WriteLine("Second thread acquired first lock");
        }
    }
}