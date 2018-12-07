<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>C:\Users\rps\Code\onedrive\csharp-samples\Frameworks\Rx\libs\System.Reactive.Core.dll</Reference>
  <Reference>C:\Users\rps\Code\onedrive\csharp-samples\Frameworks\Rx\libs\System.Reactive.Interfaces.dll</Reference>
  <Reference>C:\Users\rps\Code\onedrive\csharp-samples\Frameworks\Rx\libs\System.Reactive.Linq.dll</Reference>
  <Reference>C:\Users\rps\Code\onedrive\csharp-samples\Frameworks\Rx\libs\System.Reactive.PlatformServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
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
