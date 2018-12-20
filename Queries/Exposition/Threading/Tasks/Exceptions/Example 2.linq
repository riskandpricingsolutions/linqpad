<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

void Main()
{
	MyExtensions.SetupLog4Net();

	// 1. We log out to show we have entered the Main method and
	// highlight the thread we are running on
	LogManager.GetLogger(nameof(Main)).Info($"Main entered\n");
	try
	{
		Task<double> t = LongRunningTask();
		double result = t.Result;
	}
	catch (Exception ex)
	{
		// 3. Because Task.Result and Task.Wait we still have Main on our 
		//    call stack. Notice that the exception was raised on a background thread
		//    and caught on the thread Main is executing on. Tasks give us this for free
		LogManager.GetLogger(nameof(Main)).Info($"Caught exception of type {ex.GetType().Name} \n {MyExtensions.GetStackTraceString(1)} \n");
	}
}

Task<double> LongRunningTask()
{
	return Task<double>.Run(() =>
	{
		// 2. Raise the exception on a background thread
		LogManager.GetLogger(nameof(LongRunningTask)).Info
		($"Raising exception \n {MyExtensions.GetStackTraceString(1)}\n");
		throw new Exception("Raised on background");
		return 100.0;
	});
}