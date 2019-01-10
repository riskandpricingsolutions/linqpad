<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows</Namespace>
</Query>

public static void Main()
{
	var t3 = new Task(() => Console.WriteLine("new Task()"));
	t3.Start(new CurrentThreadScheduler(2));
}

private static void WOnLoaded(object s, RoutedEventArgs e)
{
	TaskScheduler s1 = TaskScheduler.Default;

	TaskScheduler s2 = TaskScheduler.Current;

	TaskScheduler s3 = TaskScheduler.FromCurrentSynchronizationContext();
}

class CurrentThreadScheduler : TaskScheduler
{
	private int _concurrencyLimit ;
	
	private LinkedList<Task> _tasks = new LinkedList<Task>();
	
	// Marking a static field with ThreadStatic means that each excuting
	// thread has a separate copy of the thread.
	[ThreadStatic]
	private static bool _currentThreadIsProcessingItems;
	
	public CurrentThreadScheduler(int concurrencyLimit)
	{
		_concurrencyLimit = concurrencyLimit;
	}
	
	protected override void QueueTask(Task t) 
	{
		lock ( _tasks)
		{
			_tasks.AddLast(t);
			
			//
		}
	}
		

	protected override bool TryExecuteTaskInline(Task t, bool b) 
	{
		return TryExecuteTask(t);
	}
		

	protected override IEnumerable<Task> GetScheduledTasks() =>
		Enumerable.Empty<Task>();
}