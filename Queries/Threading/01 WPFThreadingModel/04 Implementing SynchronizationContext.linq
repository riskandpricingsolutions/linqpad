<Query Kind="Program">
  <NuGetReference>log4net</NuGetReference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Repository.Hierarchy</Namespace>
  <Namespace>log4net.Config</Namespace>
  <Namespace>log4net.Appender</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>log4net.Layout</Namespace>
</Query>

public static void Main()
{




	var sc = new SingleThreadedSynchronizationContext();
	SynchronizationContext.SetSynchronizationContext(sc);
	
	var t = new Task( () => 
	{
		logger.Info("Task Running");
	});
	
	t.Start(TaskScheduler.FromCurrentSynchronizationContext());
	
}

public class SingleThreadedSynchronizationContext : SynchronizationContext
{
	public SingleThreadedSynchronizationContext()
	{
		new Thread(() =>
				{
					_logger.Info($"Starting on single thread");
					while (true)
					{
						try
						{
							_callbacks.Take()();
						}
						catch (Exception e)
						{
							Console.WriteLine(e);
						}
					}
				})
		{ Name = "SingleThreadedSynchronizationContext" }
			.Start();
	}

	public override void Post(SendOrPostCallback d, object state)
	{
		_callbacks.Add(() =>
		{
			_logger.Info("Received Post");
			d(state);
		});
	}

	public override void Send(SendOrPostCallback d, object state)
	{
		var tcs = new TaskCompletionSource<object>();

		_callbacks.Add(() =>
		{
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			d(state);
			tcs.SetResult(null);
		});

		tcs.Task.Wait();
	}

	private readonly BlockingCollection<Action> _callbacks =
		new BlockingCollection<Action>();
	
	private ILog _logger = LogManager.GetLogger(typeof(SingleThreadedSynchronizationContext));
}