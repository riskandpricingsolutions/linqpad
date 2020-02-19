<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
</Query>

void Main()
{
	var s = new MyObservable<int>();
	
	s.Subscribe(j => Console.WriteLine(j));
	s.Publish(100);
}

// Question. Create a very simple IObservable<T> type

public class MyObservable<T> : IObservable<T>
{
	public IDisposable Subscribe(IObserver<T> observer)
	{
		_observers.Add(observer);

		return Disposable.Create (() => _observers.Remove(observer) );
	}
	
	public void Publish(T e) => _observers.ForEach(j => j.OnNext(e));
	
	private List<IObserver<T>> _observers = new List<System.IObserver<T>>();
}
