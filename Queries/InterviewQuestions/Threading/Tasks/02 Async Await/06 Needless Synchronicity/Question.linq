<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

 async Task Main()
{
	logger.Info(nameof(Main));
	MyExtensions.SetupLog4Net();
	
	// Question: Improve the efficiency of this code
	var fv = await GetSpot() * Math.Exp(await GetRate());
	logger.Info(fv);
}

Task<double> GetRate() => Task.Run<double>(() =>
{
	logger.Info(nameof(GetRate));
	return 0.1;
});


Task<double> GetSpot() => Task.Run<double>(() =>
{
	logger.Info(nameof(GetSpot));
	return 100.0;
});