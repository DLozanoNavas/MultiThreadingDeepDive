var task = Task.Factory.StartNew(PrintPosts);

task.Wait(); // This way, we can choose when to wait for the task.
SomethingElse();


Console.ReadLine();

string GetPosts(string url)
{
    //throw null; // simulate error
    using var httpClient = new HttpClient();
    return httpClient.GetStringAsync(url).Result;
}

void PrintPosts()
{
    var postsTask = Task.Factory.StartNew<string>(() => GetPosts("https://jsonplaceholder.typicode.com/posts"));

    try
    {
        Console.WriteLine(postsTask.Result); // When querying task.result, the current thread will wait until the task finishes.
    }
    catch (AggregateException e) // if any exception happens When querying task.Result, the exception it will be rethrown wrapped into an AggregateException
    {
        Console.WriteLine(e.Message);
    }
}

void SomethingElse()
{
    Task.Delay(2000);
    Console.WriteLine("Something else happened.");
}