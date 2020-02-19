<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	Observable.Range(0,5).Subscribe(a=>Console.WriteLine(a),()=> Console.WriteLine("Done!"));
}

// Write code to support delegate based observers as per Rx Framework
public class DelegateBasedObserver<T> : IObserver<T>
{
	public DelegateBasedObserver(Action<T> onNext, Action<Exception> onError, Action onCompleted)
	{
		_onError = onError;
		_onCompleted = onCompleted;
		_onNext = onNext;
	}

	public DelegateBasedObserver(Action<T> onNext) => _onNext = onNext;

	public DelegateBasedObserver(Action<T> onNext, Action onCompleted)
	{
		_onNext = onNext;
		_onCompleted = onCompleted;
	}

	public void OnCompleted() => _onCompleted();

	public void OnError(Exception error) => _onError(error);

	public void OnNext(T value) => _onNext(value);
	
	private Action<T> _onNext;
	private Action<Exception> _onError;
	private Action _onCompleted;
}

public static class MyObservable
{
	public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action done)
	{
		var dbo = new DelegateBasedObserver<T>(onNext,done);
		return source.Subscribe(dbo);
	}
}
