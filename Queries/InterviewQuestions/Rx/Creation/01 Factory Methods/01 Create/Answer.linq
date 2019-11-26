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

	// Question: Create an observable sequence of three integers
	IObservable<int> observable = Observable.Create<int>(o =>
	{
		o.OnNext(1);
		o.OnNext(2);
		o.OnNext(3);
		o.OnCompleted();
		return Disposable.Empty;
	});
	
	observable.Subscribe(o => logger.Info(o));
}

