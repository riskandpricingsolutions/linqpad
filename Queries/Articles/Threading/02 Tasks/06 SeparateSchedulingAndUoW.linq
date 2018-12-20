<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

public static void Main()
{
	MyExtensions.SetupLog4Net();
	
	Task t1 = new Task(Function);
	Task t2 = new Task(Function);

	t1.Start(TaskScheduler.Default);
	t2.Start(TaskScheduler.Current);
}

static void Function()
{
	LogManager.GetLogger("Separate Scheduling Example").Info("Function");
}