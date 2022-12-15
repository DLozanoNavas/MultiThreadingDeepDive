var task = new Task(SimpleMethod);
task.Start();

var taskThatReturns = new Task<string>(MethodThatReturns);
taskThatReturns.Start();
taskThatReturns.Wait();
var blockingResult =  taskThatReturns.Result;
Console.WriteLine(blockingResult);

var nonBlockingResult = await taskThatReturns;
Console.WriteLine(nonBlockingResult);

Console.ReadLine();

void SimpleMethod()
{
    Console.WriteLine("Hello from task");
}

string MethodThatReturns()
{
    Task.Delay(5000);
    return "Hello from method that returns";
}