<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info("Main() started");


	Task<Task<double>> antecedent = new Task<Task<double>>(() => OuterFunction(4.0));

	antecedent.ContinueWith(a =>
	{
		a.Result.ContinueWith(r => 
		{
			logger.Info($"Final result({r.Result})");
		});
	});
	
	antecedent.Start(TaskScheduler.Default);
}


public Task<double> OuterFunction(double x)
{		
	Task<double> innerTask = InnerFunction(x)
		.ContinueWith(c => c.Result * c.Result);
	
	return innerTask;
}

public Task<double> InnerFunction(double x)
{
	return Task<double>.Run(() =>
	{
		logger.Info($"InnerFunction({x})");
		return 2 * x;
	});

}