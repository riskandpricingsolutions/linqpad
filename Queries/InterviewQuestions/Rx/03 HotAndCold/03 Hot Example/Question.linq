<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	// In this example we wrap our observable in a ConnectableObservable 
	// and connect it before we make any subscriptions. By doing this we are
	// creating what is known as a Hot Observable. This Observable is still
	// publishing values even though it has no subscriptions.
	SimpleObservable<int> sourceObservable = new SimpleObservable<int>();

	// Question: Given the source observable, create a hot observable
	

	IConnectableObservable<int> connectableObservable 
		= sourceObservable.Publish();
		
	connectableObservable.Connect();
	
	sourceObservable.Publish(10);
	
	

}

public class SimpleObservable<T> : IObservable<T>
{
	private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

	public IDisposable Subscribe(IObserver<T> observer)
	{
		_observers.Add(observer);
		return Disposable.Empty;
	}

	public void Publish(T m) => _observers.ForEach(obs => obs.OnNext(m));
}