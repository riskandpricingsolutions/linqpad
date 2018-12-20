<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

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

Task CancellationExceptionAwaiter()
{
	TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
	Task t = new Task(() => {});
	tcs.SetCanceled();
	return tcs.Task;
}