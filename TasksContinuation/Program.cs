// Continuation: Asynchronous task invoked by another task called an antecedent.
// Task chaining allows to:
// - Pass data from an antecedent to the continuation task
// - Pass exceptions to antecedent to continuation task (for continuation to handle)
// - Control how the continuation is invoked
// - Cancel a continuation not only before it starts, but also while the continuation is running.
// - Invoke multiple continuations from the same antecedent
// - Invoke continuations when all or any of the antecedents complete (WhenAll/WhenAny)

var antecedent = Task.Factory.StartNew(() =>
{
    Task.Delay(5000);
    return DateTime.Today.ToShortDateString();
});

var continuation = antecedent.ContinueWith(t =>
{
    Task.Delay(5000);
    return $"Today is {t.Result}";
});

//Console.WriteLine("This will be printed before the result of the continuation");

Console.WriteLine(continuation.Result);