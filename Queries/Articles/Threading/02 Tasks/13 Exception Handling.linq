<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

public static void Main()
{
	MyExtensions.SetupLog4Net();
	TaskExceptionTest();
}


public static Task GetExceptionTask()
{
	return Task.Run(() =>
	{
		LogManager.GetLogger("GetExceptionTask").Info("exception raised");
		throw new ArgumentException();
	});
}

public static void TaskExceptionTest()
{
	try
	{
		var exceptionTask = GetExceptionTask();
		exceptionTask.Wait();
	}
	catch (Exception e)
	{
		LogManager.GetLogger("GetExceptionTask").Info($"Exception {e.GetType()}");
		LogManager.GetLogger("GetExceptionTask").Info($"Inner exception {e.InnerException.GetType()}");
	}
}