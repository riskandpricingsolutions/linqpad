<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

async void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info(nameof(Main));

	// Question: Show what happens in this expression
	double forward = GetForward(await GetSpot(), await GetRate());
	logger.Info(forward);
	
	Task<double> spotTask = GetSpot();
	double spot = await spotTask;
	Task<double> rateTask = GetRate();
	double rate = await rateTask;
	double forward2 = GetForward(spot,rate);
	logger.Info(forward2);
}



public double GetForward(double spot, double rate) => spot * Math.Exp(rate);

public Task<double> GetSpot()
{
	return Task.Run(() => 100.0);
}

public Task<double> GetRate()
{
	return Task.Run(() => 0.1);
}