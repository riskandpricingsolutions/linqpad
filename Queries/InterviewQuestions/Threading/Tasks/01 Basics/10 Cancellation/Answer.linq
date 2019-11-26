<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Question: Write code to wait on a long running task which 
	//           gets cancelled
	CancellationTokenSource cts = new CancellationTokenSource();
	CancellationToken token = cts.Token;
	cts.CancelAfter(TimeSpan.FromSeconds(2));
	
	Task t = Task.Delay(TimeSpan.FromSeconds(20),token);
	try
	{
		t.Wait();
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex);
	}
	
	
}

