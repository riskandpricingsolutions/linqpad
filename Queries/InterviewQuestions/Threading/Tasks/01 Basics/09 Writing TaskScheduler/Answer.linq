<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
	// Question: Implement a TaskScheduler that immediately 
	//           executes code on current thread. Demonstrate
	//           its use.
	SingleThreadedScheduler scheduler = new SingleThreadedScheduler();
	Task t = new Task(() => Console.WriteLine(Thread.CurrentThread.ManagedThreadId));
	t.Start(scheduler);
}

public class SingleThreadedScheduler : TaskScheduler
{
	protected override IEnumerable<Task> GetScheduledTasks() => Enumerable.Empty<Task>();
	protected override void QueueTask(Task task) => TryExecuteTask(task);
	protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) => TryExecuteTask(task);
}