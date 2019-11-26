<Query Kind="Program">
  <Namespace>log4net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	// Question: Write a simple awaiter that returns immediately

	AwaitableType<double> a = new AwaitableType<double>(100.0);
	var awaiter = a.GetAwaiter();
	
	awaiter.OnCompleted(() =>
   {
   		logger.Info(awaiter.GetValue());
   });
}
