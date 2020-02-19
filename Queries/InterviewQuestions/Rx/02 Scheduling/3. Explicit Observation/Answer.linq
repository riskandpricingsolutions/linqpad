<Query Kind="Program">
  <Reference>M:\Libraries\DotNetAssemblies\Rps\Rx\BasicImplementations.dll</Reference>
  <Reference>M:\Libraries\DotNetAssemblies\Rps\Utilities\Logging.dll</Reference>
  <Reference>M:\Libraries\DotNetAssemblies\Rx\System.Reactive.Core.dll</Reference>
  <Reference>M:\Libraries\DotNetAssemblies\Rx\System.Reactive.Interfaces.dll</Reference>
  <Reference>M:\Libraries\DotNetAssemblies\Rx\System.Reactive.Linq.dll</Reference>
  <Namespace>RiskAndPricingSolutions.Rx.SharedResources.BasicImplementations</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net("[%thread]  %message%newline");
	// 1. Log out the calling thread
	
	logger.Info("ExplicitMultiThreadedObservation");

	// 2. Create a scheduler with its own thread and a 
	//    wait handle to prevent premature completion
	IScheduler scheduler = new SingleThreadedScheduler("KennysScheduler");
	AutoResetEvent handle = new AutoResetEvent(false);

	// 3. Create observable tell it we want to observer
	//    on our explicit scheduler
	var observable = new SimpleObservable<int>();
	var disposable = observable
		.ObserveOn(scheduler)
		.Subscribe(i => Console.WriteLine(i), () => handle.Set());

	// 4. Publish 2 messages and then complete 
	observable.Publish(1);
	observable.Publish(2);
	observable.Complete();

	handle.WaitOne();


}
