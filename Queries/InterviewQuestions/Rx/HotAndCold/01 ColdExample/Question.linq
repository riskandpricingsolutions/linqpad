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

	int x = 0;
	IDisposable FactoryMethod(IObserver<int> observer)
	{
		observer.OnNext(x++);
		observer.OnCompleted();
		return Disposable.Empty;
	}

	IObservable<int> observable = Observable.Create<int>(FactoryMethod);
	observable.Subscribe(o => Console.WriteLine($"A {o}") );
	observable.Subscribe(o => Console.WriteLine($"B {o}") );
	


}

// Define other methods and classes here
