<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	Console.WriteLine(await GetForwardAwaiter());
}

public async Task<double> GetForward()
{
	double r = await GetRate();
	double b = await GetBorrowCost();
	double s = await GetSpot();

	return s * Math.Exp(r - b);
}

public Task<double> GetForwardAwaiter()
{
	double r, b, s;
	var tcs = new TaskCompletionSource<double>();

	var ra = GetRate().GetAwaiter();
	var ba = GetBorrowCost().GetAwaiter();
	var sa = GetSpot().GetAwaiter();

	ra.OnCompleted(() =>
	{
		r = ra.GetResult();
		ba.OnCompleted(() =>
		{
			b = ba.GetResult();
			sa.OnCompleted(() =>
			{
				s = sa.GetResult();
				tcs.SetResult(s * Math.Exp(r - b));
			});
	   });
   });

	return tcs.Task;
}

Task<double> GetRate() => Task.Run(() => 0.1);
Task<double> GetBorrowCost() => Task.Run(() => 0.05);
Task<double> GetSpot() => Task.Run(() => 100.0);

// Define other methods and classes here