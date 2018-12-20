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
	
	TaskAwaiter<double> awaiter = GetSpotPrice().GetAwaiter();

	awaiter.OnCompleted(() =>
    {
		try
		{
			logger.Info(awaiter.GetResult());
		}
		catch (Exception ex)
		{
			logger.Info($"{ex.GetType().Name}");
		}
		
    });
}

public Task<double> GetSpotPrice()
{
	return Task.Run(() =>
	{
		throw new Exception("Something happened");
		return 0.0;
	});
}