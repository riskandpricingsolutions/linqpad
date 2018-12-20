<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

void Main()
{
	MyExtensions.SetupLog4Net();

	// 1. We log out to show we have entered the Main method and
	// highlight the thread we are running on
	LogManager.GetLogger(nameof(Main)).Info($"Main entered \n");

	Task<double> t = LongRunningTask();
	TaskAwaiter<double> a = t.GetAwaiter();
	a.OnCompleted(() =>
   {
	   try
	   {
		   double result = a.GetResult();
	   }
	   catch (Exception ex)
	   {
		   // 3. We have three things we need to note now when using an awaiter. The 
		   //    first is that the exception was raised on a background thread and caught 
		   //    on the same background thread. The original method Main is no longer on the
		   //    stack. Note also awaiter unwrapped the agreggate exception for us
		   LogManager.GetLogger(nameof(Main)).Info($"Caught exception of type {ex.GetType().Name} \n {MyExtensions.GetStackTraceString(1)} \n");
	   }
   });
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