Thread.CurrentThread.Name = "Main Thread";

Demo();
Demo2();

void Demo()
{
    try
    {
        new Thread(Execute)
        {
            Name = "Worker Thread 1"
        }.Start();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message); // Exception won't be caught here because exception handling is done on a per-thread basis.
    }
}

void Execute()
{
    throw null;
}

void Demo2()
{

    new Thread(Execute2)
    {
        Name = "Worker Thread 2"
    }.Start();
}

void Execute2()
{
    try
    {
        throw null;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message); // Exception will get caught here because exception handling is done on a per-thread basis.
    }
}