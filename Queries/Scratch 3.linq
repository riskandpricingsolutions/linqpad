<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info("Main() started");


	Task<Task<double>> forwardTask = GetForward("SX5E", "EUR");
	double forward = forwardTask.Result.Result;
	Console.WriteLine(forward);
}


public Task<Task<double>> GetForward(string stockSymbol, string index)
{		
	Task<double> spotTask = GetSpotPrice(stockSymbol);
	Task<double> rateTask = GetRate(index);

	Func<Task<double>,Task<double>> spotContWork = (s)  =>
	{
		Func<Task<double>, double> rateContinuationWork = (r) =>
		 {
			 return s.Result * Math.Exp(r.Result);
		 };

		Task<double> rateContinuationTask = rateTask.ContinueWith(rateContinuationWork);
		return rateContinuationTask;
	};

	Task<Task<double>> forwardTask = spotTask.ContinueWith(spotContWork);
	
	return forwardTask;
}

public Task<double> GetSpotPrice(string stockSymbol)
{
	Func<double> work = () =>
	{
		logger.Info($"GetSpotPrice()");
		return 100.0;
	};

	Task<double> task = new Task<double>(work);
	task.Start(TaskScheduler.Default);
	return task;
}

public Task<double> GetRate(string index)
{
	Func<double> work = () =>
	{
		logger.Info($"GetRate()");
		return 0.1;
	};

	Task<double> task = new Task<double>(work);
	task.Start(TaskScheduler.Default);
	return task;
}