<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Answer:	Implement the method CancellationExceptionAwaiter so that it works
// 				exactly the same as CancellationExceptionTAsync. The console logs should
//				be the same irrespective of whether we use CancellationExceptionTAsync or 
//				CancellationExceptionAwaiter to asign the Task t in the Main method
void Main()
{
	Task t = CancellationExceptionTask();
	Console.WriteLine(t.Status);
	
	try
	{
		t.Wait();
	}
	catch (Exception ex)
	{
		Console.WriteLine($"{t.Status} {ex.GetType().Name} {ex.InnerException.GetType().Name}");
	}
}

async Task CancellationExceptionTask()
{
	throw new OperationCanceledException();
}

// Answer
Task CancellationExceptionAwaiter()
{
	TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
	Task t = new Task(() => {});
	tcs.SetCanceled();
	return tcs.Task;
}