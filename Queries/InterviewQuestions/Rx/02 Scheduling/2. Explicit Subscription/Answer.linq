<Query Kind="Program">
  <Reference>M:\Libraries\DotNetAssemblies\Rps\Rx\BasicImplementations.dll</Reference>
  <Reference>M:\Libraries\DotNetAssemblies\Rps\Utilities\Logging.dll</Reference>
  <Reference>M:\Libraries\DotNetAssemblies\Rx\System.Reactive.Core.dll</Reference>
  <Reference>M:\Libraries\DotNetAssemblies\Rx\System.Reactive.Interfaces.dll</Reference>
  <Reference>M:\Libraries\DotNetAssemblies\Rx\System.Reactive.Linq.dll</Reference>
  <Namespace>RiskAndPricingSolutions.Rx.SharedResources.BasicImplementations</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// Question: Show how to subscribe on another thread
	
	// 1. Create an observable
	var observable = new SimpleObservable<int>();
	
	// 2. Create an observer
	var observer = new SimpleObserver<int>();
	
	// 3. Create a simple scheduler
	IScheduler scheduler = new SingleThreadedScheduler("Kenny's Scheduler");
	
	// 4. Register the observer with the observable
	var disposable = observable.SubscribeOn(scheduler).Subscribe(observer);
	
	// Make sure publish does not happen before subscribe finishes
	Thread.Sleep(100);
	
	// 5. Publish a value
	observable.Publish(3);
	
	// 6. Dispose
	disposable.Dispose();
	
}

// Question: