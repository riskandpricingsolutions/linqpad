<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var source = new CancellationTokenSource();

	Task t = LongRunningAsyncMethod(source.Token);
	
	source.CancelAfter(2);

	try
	{
		t.Wait();
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Caught {ex.InnerException}");
	}

	Console.WriteLine($"Final status: {t.Status}");
}

static async Task LongRunningAsyncMethod(CancellationToken token)
{
	await Task.Delay(TimeSpan.FromSeconds(20), token);
}