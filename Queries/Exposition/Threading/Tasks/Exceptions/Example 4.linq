<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

async Task Main()
{
	MyExtensions.SetupLog4Net();

	// 1. We log out to show we have entered the Main method and
	// highlight the thread we are running on
	LogManager.GetLogger(nameof(Main)).Info($"Main entered \n");

	try
	{
		Task<double> t = LongRunningTask();
		double result = await t;
	}
	catch (Exception ex)
	{
		// 3. The internals of async/await mechanism use awaiters so this is now executing
		//    on a background thread and Main is no longer on the call stack. The exception
		//    is unwrapped from the Task AggregateException
		LogManager.GetLogger(nameof(Main)).Info($"Caught exception of type {ex.GetType().Name} \n {MyExtensions.GetStackTraceString(1)} \n");
	}
}



Task<double> LongRunningTask()
{
	return Task<double>.Run(() =>
	{
		// 2. Raise the exception on a background thread
		LogManager.GetLogger(nameof(LongRunningTask)).Info
		($"Raising exception \n {MyExtensions.GetStackTraceString(1)} \n");
		throw new Exception("Raised on background");
		return 100.0;
	});
}