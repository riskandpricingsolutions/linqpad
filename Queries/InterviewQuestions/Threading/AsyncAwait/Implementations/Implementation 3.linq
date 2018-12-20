<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

async void Main()
{
	Console.WriteLine(await GetSumAwaiter());
}

public static Task<double> GetDouble(int i) => Task.Run(() => i * 10000.0);

public async Task<double> GetSum()
{
	double result = 0.0;
	
	for (int i = 1; i <= 5; i++)
	{
		result += await GetDouble(i);
	}
	
	return result;
}

public Task<double> GetSumAwaiter()
{
	StateMachine s = new StateMachine();
	s.MoveNext();
	return s.Task;
}

public class StateMachine
{
	public double result = 0.0;
	public int i = 1;
	public TaskCompletionSource<double> tcs = new TaskCompletionSource<double>();
	public TaskAwaiter<double> ta;
	public Task<double> Task;
	
	public StateMachine()
	{
		Task = tcs.Task;
	}
	
	public void MoveNext()
	{
		if ( i <=5)
		{
			ta = GetDouble(i++).GetAwaiter();
			ta.OnCompleted(() =>
		    {
				result+= ta.GetResult();
				MoveNext();
		    });
		}		
		else 
		{
			// Special case for the end
			tcs.SetResult(result);
		}	
	}	
}


// Define other methods and classes here