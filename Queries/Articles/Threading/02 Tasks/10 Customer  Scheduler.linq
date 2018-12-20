<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows</Namespace>
</Query>

public static void Main()
{
	var t3 = new Task(() => Console.WriteLine("new Task()"));
	t3.Start(new CurrentThreadScheduler());
}

private static void WOnLoaded(object s, RoutedEventArgs e)
{
	TaskScheduler s1 = TaskScheduler.Default;

	TaskScheduler s2 = TaskScheduler.Current;

	TaskScheduler s3 = TaskScheduler.FromCurrentSynchronizationContext();
}

class CurrentThreadScheduler : TaskScheduler
{
	protected override void QueueTask(Task t) =>
		TryExecuteTask(t);

	protected override bool TryExecuteTaskInline(Task t, bool b) =>
		TryExecuteTask(t);

	protected override IEnumerable<Task> GetScheduledTasks() =>
		Enumerable.Empty<Task>();
}