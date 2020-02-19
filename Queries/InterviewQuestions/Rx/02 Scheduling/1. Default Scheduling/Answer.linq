<Query Kind="Program">
  <Reference>M:\Libraries\DotNetAssemblies\Rps\Rx\BasicImplementations.dll</Reference>
  <Namespace>RiskAndPricingSolutions.Rx.SharedResources.BasicImplementations</Namespace>
</Query>

void Main()
{
	// Question: Show the basic thread scheduling scenario
	
	// 1. Create an observable
	var observable = new SimpleObservable<int>();
	
	// 2. Create an observer
	var observer = new SimpleObserver<int>();
	
	// 3. Register the observer with the observable
	var disposable = observable.Subscribe(observer);
	
	// 4. Publish a value
	observable.Publish(3);
	
	// 5. Dispose
	disposable.Dispose();
	
}

// Question:

