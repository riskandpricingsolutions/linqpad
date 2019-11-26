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
	AsyncAwaitMethod();
	
	AwaiterMethod();
}

public async void AsyncAwaitMethod()
{
	Task t = Task.Run (() => logger.Info("Running"));
	await t;
	logger.Info("Completed");
}


public async void AwaiterMethod() => throw new NotImplementedException();