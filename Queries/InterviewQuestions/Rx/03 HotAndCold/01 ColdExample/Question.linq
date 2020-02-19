<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	// Question: 	Write code to highlight the properties of a cold observable.

	int x = 0;
	IDisposable FactoryMethod(IObserver<int> observer)
	{
		observer.OnNext(x++);
		observer.OnCompleted();
		return Disposable.Empty;
	}

	// Turn our Factory method into an Observable
	IObservable<int> observable = Observable.Create((Func<IObserver<int>,IDisposable>)FactoryMethod);

	// Perform two different subscriptions. Each IOBserver 
	// get different values to the nature of a cold observable
	observable.Subscribe(o => WriteLine($"A {o}"));
	observable.Subscribe(o => WriteLine($"B {o}"));

}

// Define other methods and classes here