<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

async void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info(nameof(Main));
	
	Task<double> fTask = GetForward();
	logger.Info("GetForward returned");
	
	double fwd = await fTask;
	logger.Info(fwd);

}

public async Task<double> GetForward()
{
	logger.Info(nameof(GetForward));
	
	double rate = await GetRate();
	logger.Info(rate);
	
	double spot = await GetSpot();
	logger.Info(spot);
	
	return spot * Math.Exp(rate);	
}

public Task<double> GetSpot()
{
	return Task.Run(() => 100.0);
}

public async Task<double> GetRate()
{
	return 0.1;
}