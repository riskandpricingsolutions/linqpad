<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Question: The following method runs a task that increments 
	//           ints input and returns it. Chain 5 such calls together
	//           such that the result it 5

	Task<int> Increment(int x)
	{
		return Task.Run(() =>
		{
			Console.WriteLine(nameof(Increment));
			return ++x;
		});
	}

	Task<int> one = Increment(0)
		.ContinueWith(ant=> Increment(ant.Result) )
		.Unwrap()
		.ContinueWith(ant => Increment(ant.Result))
		.Unwrap()
		.ContinueWith(ant => Increment(ant.Result))
		.Unwrap();
		
	one.ContinueWith(o => Console.WriteLine(o.Result));
}