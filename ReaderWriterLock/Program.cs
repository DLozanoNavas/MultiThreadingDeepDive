// Reader/Writer locks slim
// - Reader/Writer locks allow multiple threads to read a resource at the same time.
// - Reader/Writer locks allow only one thread to write to a resource at a time.
// - Reader/Writer locks are also known as shared/exclusive locks.

// ReaderWriterLockSlim is a class introduced in .NET Framework 4.0 that provides a reader/writer lock.
// - It is a lightweight version of the ReaderWriterLock class.
// - It is a value type and does not require the use of the using statement.
// - It is a good choice for most scenarios.

namespace ReaderWriterLock;

static class Program
{
    static ReaderWriterLockSlim readerWriterLockSlim = new ();

    static void Main(string[] args)
    {
        var tasks = new List<Task>();

        for (var i = 0; i < 10; i++)
        {
            tasks.Add(Task.Factory.StartNew(() =>
            {
                readerWriterLockSlim.EnterReadLock();
                Console.WriteLine($"Read lock acquired by task {Task.CurrentId}");
                Thread.Sleep(1000);
                readerWriterLockSlim.ExitReadLock();
            }));
        }

        for (var i = 0; i < 10; i++)
        {
            tasks.Add(Task.Factory.StartNew(() =>
            {
                readerWriterLockSlim.EnterWriteLock();
                Console.WriteLine($"Write lock acquired by task {Task.CurrentId}");
                Thread.Sleep(1000);
                readerWriterLockSlim.ExitWriteLock();
            }));
        }

        Task.WaitAll(tasks.ToArray());

        Console.ReadLine();
    }
}