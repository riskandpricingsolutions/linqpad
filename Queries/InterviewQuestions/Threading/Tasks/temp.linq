<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

async void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info(nameof(Main));
	
	await DoIt();
	
	logger.Info(nameof(Main));
}

public async Task DoIt()
{
	double forward = await GetForward();
	logger.Info(forward);
}

public async Task<Double> GetForward()
{
	double spot = await GetSpot();
	
	double rate = await GetRate();
	
	return spot * Math.Exp(rate);
}

public Task<double> GetSpot()
{
	return Task.Run (() => 100.0) ;
}

public Task<double> GetRate()
{
	return Task.Run (() => 0.1) ;
}