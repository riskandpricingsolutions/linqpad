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
	LogManager.GetLogger(nameof(Main)).Info($"Main entered");
	try
	{
		Task<double> t = LongRunningTask();
	}
	catch (Exception ex)
	{
		// 3. No task was every created or executed so this exception is
	    //    caught on the Main Query Thread and the stack trace has this 
		//    Method itself on it
		LogManager.GetLogger(nameof(Main)).Info($"Caught exception of type {ex.GetType().Name}  \n\n {MyExtensions.GetStackTraceString(1)} \n");
	}
}

Task<double> LongRunningTask()
{
	// 2. No task is every created so the exception is raised on 
	//    the calling thread
	LogManager.GetLogger(nameof(LongRunningTask)).Info($"Raising exception");
	throw new NotImplementedException();
}