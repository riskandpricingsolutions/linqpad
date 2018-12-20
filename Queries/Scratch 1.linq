<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	try
	{
		var result = Getspot()
			.ContinueWith(x => GetRate(x.Result))
			.ContinueWith(x =>
		   {
		   		try{
					Console.WriteLine(x.Result);
			   }
			   catch (Exception ex)
			   {
				   Console.WriteLine($"Something {ex.GetType()}");
			   }
		   });
		   
		   result.Wait();		
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Something {ex.GetType()}");
	}
	
}



public Task<double> Getspot()
{
	return Task.Run (() => 100.0);
}

public Task<double> GetRate(double spot)
{
	return Task.Run(() =>
	{
		throw new ArgumentException("Something wrong");
		return 100.0;
	});
}