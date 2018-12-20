<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

async Task Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info("Main() started");


	Task<double> antecedent = new Task<double>(() => Function1(4.0, true));
	Task<double> continuation = antecedent.ContinueWith(x => Function2(x.Result));

	Task finalContinuation = continuation.ContinueWith(c =>
	{
		logger.Info($"{c.Status}");
		
		if (c.Status == TaskStatus.Faulted)
			logger.Info($"{c.Exception.Message}");		
	});	
	
	antecedent.Start(TaskScheduler.Default);
	
	await finalContinuation;
	logger.Info("Main() completed");
}

public double Function1(double x, bool throwsEx=false)
{
	if (throwsEx)
		throw new Exception("Function1 Exception");
		
	logger.Info($"Function1({x})");
	return x * x;
}

public double Function2(double x)
{
	logger.Info($"Function2({x})");
	return 2 * x;
}


