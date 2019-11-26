<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

	Action a = () => Console.WriteLine($"Antecedent {Thread.CurrentThread.ManagedThreadId}");
	Action b = () => Console.WriteLine($"Continuation {Thread.CurrentThread.ManagedThreadId}");

	// Question: Use the below scheduler to schedule action a on the current thread. Then
	//           schedule b as a continuation on the same thread
}

/// A TaskScheduler than executes tasks immediately
/// on whatever threads its methods are invoked on
/// </summary>

public class CurrentThreadTaskScheduler : TaskScheduler
{
	protected override void QueueTask(Task task)

	{
		TryExecuteTask(task);
	}

	protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)

	{
		return TryExecuteTask(task);
	}

	protected override IEnumerable<Task> GetScheduledTasks()
	{
		return Enumerable.Empty<Task>();
	}
}