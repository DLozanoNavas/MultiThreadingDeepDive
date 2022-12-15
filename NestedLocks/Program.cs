// When we have nested locks, only the most outer lock us relevant.

object lockObject = new object();

lock (lockObject)
{
    OtherStuff();
}

void OtherStuff()
{
    lock (lockObject)
    {
        Task.Delay(1000);
        // Do something
        MoreStuff();
    }
}

void MoreStuff()
{
    lock (lockObject)
    {
        // Do something
        Console.WriteLine("Hello World");
    }
}
