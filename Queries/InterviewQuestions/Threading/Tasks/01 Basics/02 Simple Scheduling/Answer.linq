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
	
	t1.Start(TaskScheduler.Default);
	t2.Start(TaskScheduler.Current);
}

// Define other methods and classes here
