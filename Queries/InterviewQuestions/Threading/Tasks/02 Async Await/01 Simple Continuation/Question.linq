<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

void Main()
{
	MyExtensions.SetupLog4Net();
	LogManager.GetLogger(nameof(Main)).Info($"Main Thread \n");

	// Question: Write code to perform a continuation after the spot
	//           price is ready. Use an awaiter
}

// Define other methods and classes here
public Task<double> GetSpotPrice()
{
	return Task.Run(() =>
	{
		LogManager.GetLogger(nameof(Main)).Info($"Task Running \n");
		return 110.0;
	});
}