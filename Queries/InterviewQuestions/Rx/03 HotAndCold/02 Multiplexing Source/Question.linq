<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();


	// As per the previous sample we use a factory method together
	// with Observable.Create to create an IObservable which delivers
	// completely different values from each subscription. The key 
	// difference is that we wrap this Observable 
	// with a ConnectableObservable 
	// using the Publish extension method. This extra layer allows us to
	// share the values published from the originating Observable as the
	// Connectable wrapper performs the multiplexing
	int x = 0;

	// Define a factory method that when invoked directly calls OnNext
	IDisposable FactMethod(IObserver<int> observer)
	{
		observer.OnNext(x++);
		return Disposable.Empty;
	}

	// Use the Observable.Create to turn our factory method into an IObservable
	IObservable<int> observable = Observable.Create((Func<IObserver<int>, IDisposable>)FactMethod);

	// Question: Given observable write code to ensure two subscribers get the same data
	IConnectableObservable<int> connectableObservable = observable.Publish();

	connectableObservable.Subscribe(o => WriteLine($"A {o}"));
	connectableObservable.Subscribe(o => WriteLine($"B {o}"));
	
	connectableObservable.Connect();


}

// Define other methods and classes here