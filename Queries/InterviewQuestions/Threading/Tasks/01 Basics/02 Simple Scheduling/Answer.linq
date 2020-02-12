<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Question: Schedule the following UoW on the two default schedulers
	void Function()
	{
		Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
	}
	
	Task t1 = new Task(Function);
	Task t2 = new Task(Function);
	Task t3 = new Task(Function);
	
	// Use the thread pool
	t1.Start(TaskScheduler.Default);
	
	// Use the thread the current task is running on.
	// When not executing on a task use the default scheduler
	t2.Start(TaskScheduler.Current);
}

// Define other methods and classes here