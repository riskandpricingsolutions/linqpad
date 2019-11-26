<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

 async Task Main()
{
	logger.Info(nameof(Main));
	MyExtensions.SetupLog4Net();

	// Question: Implment the below AwaiterMethod so that
	// it does the same as AsyncAwaitMethod
	double result = CalcForward().Result;
	logger.Info(result);
	
	double res2 = CalcForwardAwaiter().Result;
	logger.Info(res2);
}

public async Task<double> CalcForward()
{
	Task<double> getSpotTask = GetSpot();
	Task<double> getRateTask = GetRate();
	Task<double> getBorrowTask = GetBorrow();

	double fwd = await getSpotTask * Math.Exp(await getRateTask - await getBorrowTask);
	return fwd;
}

public Task<double> CalcForwardAwaiter() => throw new NotImplementedException();

public Task<Double> GetRate() => Task.Run<double>(() => 0.1);
public Task<Double> GetBorrow() => Task.Run<double>(() => 0.05);
public Task<Double> GetSpot() => Task.Run<double>(() => 100);