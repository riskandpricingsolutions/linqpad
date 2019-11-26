<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

 async Task Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info("Main Running");
	// Question: Write code to call the GetSpotPrice in
	//           using async await
	
	double spotPrice = await GetSpotPrice();
	logger.Info("Got result");
}

public static Task<double> GetSpotPrice()
{
	return Task.Run(() =>
	{
		logger.Info("Task running");
		return 110.0;
	});
}