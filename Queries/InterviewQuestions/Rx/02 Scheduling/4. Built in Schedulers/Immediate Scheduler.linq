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
	
	Observable.Range(0,10).ObserveOn( Scheduler.Immediate)
		.SubscribeOn(Scheduler.Immediate)
		.Subscribe( a=> logger.Info(a));
		
	logger.Info("Ended");
}

// Define other methods and classes here
