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
	int result = AsyncAwaitMethod().Result;
	logger.Info(result);
	
	int res2 = AwaiterMethod().Result;
	logger.Info(res2);
}

public async Task<int> AsyncAwaitMethod()
{
	Task<int> t = Task.Run<int> (() => 100);
	await t;
	return t.Result;
	logger.Info("Completed");
}


public Task<int> AwaiterMethod() => throw new NotImplementedException();