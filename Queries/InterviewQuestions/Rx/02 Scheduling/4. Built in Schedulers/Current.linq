<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net("[%thread]  %message%newline");
	logger.Info("");
	
	Scheduler.
	
	Observable.Range(0,10).ObserveOn( Scheduler.Immediate)
		.ObserveOn(Scheduler.CurrentThread)
		.Subscribe(o =>
		{
			
		})
	
		
	logger.Info("Ended");
}

// Define other methods and classes here