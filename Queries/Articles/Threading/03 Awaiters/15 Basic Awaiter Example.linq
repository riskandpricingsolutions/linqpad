<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info("Main() started");	

	Task<double> task = GetSpotPrice();
	
	TaskAwaiter<double> awaiter = task.GetAwaiter();

	awaiter.OnCompleted(() =>
    {
		logger.Info(awaiter.GetResult());
    });
}


public Task<double> GetSpotPrice()
{
	return Task.Run(() =>
	{
		logger.Info("Task running");
		return 110.0;
	});
}