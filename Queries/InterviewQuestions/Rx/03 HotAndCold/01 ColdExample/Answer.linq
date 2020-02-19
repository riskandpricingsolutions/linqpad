<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	// Question: 	Write code to highlight the properties of a cold observable.

	// We use a factory method together with Observable.Create to create
	// an IObservable which delivers completely different values to each 
	// Subscription. This is the basic property of a ColdObservable. 
	// Nothing is delivered util a subscription is made and each 
	// subscription gets a different value.
	int x = 0;

	// Define a factory method that when invoked directly calls OnNext
	IDisposable FactMeth(IObserver<int> observer)
	{
		observer.OnNext(x++);
		return Disposable.Empty;
	}

	// Use Observable.Create to turn our factory method into an IObservable
	var observable = Observable.Create((Func<IObserver<int>, IDisposable>)FactMeth);

	// Perform two different subscriptions. Each IOBserver 
	// get different values to the nature of a cold observable
	observable.Subscribe(i => Console.WriteLine($"A {i}"));
	observable.Subscribe(i => Console.WriteLine($"B {i}"));

}

// Define other methods and classes here
