<Query Kind="Program">
  <NuGetReference>Microsoft.Reactive.Testing</NuGetReference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>Microsoft.Reactive.Testing</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	logger.Info(nameof(Main));
	MyExtensions.SetupLog4Net();
			
	TestScheduler t = new TestScheduler();
	DoSubscription(t);
	t.Start();
}

public void DoSubscription(IScheduler scheduler)
{
	IObservable<long> observable = Observable
	.Interval(TimeSpan.FromSeconds(1),scheduler)
	.Take(5);
	
	observable
		.ObserveOn(scheduler)
		.Subscribe(e => logger.Info(e));
}



// Define other methods and classes here
