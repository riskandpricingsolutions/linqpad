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
	
	logger.Info("Range");
	// Question: Use Generate to Implement Range, Interval, Timer(Timespan) and Timer(Timespan,Timespan
	MyObservable.Range(0,5)
		.Subscribe(o => logger.Info($"OnNext({o})"),()=>logger.Info("OnCompleted()"));
	WriteLine();

	logger.Info("Timer(TimeSpan)");
	MyObservable.Timer(TimeSpan.FromSeconds(2))
		.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));
	Thread.Sleep(3000);
	WriteLine();	
	
	logger.Info("Timer(TimeSpan,TimeSpan)");
	MyObservable.Timer(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1))
		.Take(5)
		.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));
	Thread.Sleep(12000);
	WriteLine();

	logger.Info("Iterval(TimeSpan)");
	MyObservable
	.Interval(TimeSpan.FromSeconds(1))
	.Take(5)
	.Subscribe(o => WriteLine($"OnNext({o})"),() => logger.Info("OnCompleted()"));

}

public static class MyObservable
{
	public static IObservable<int> Range(int start, int count)
	{
		return Observable.Generate(start,i=> i<(start+count),i=>++i,i=>i);
	}
	
	public static IObservable<int> Timer(TimeSpan timespan)
	{
		return Observable.Generate(0,i=>i<1,i=>++i,i=>i,i=>timespan);
	}

	public static IObservable<int> Timer(TimeSpan duePeriod, TimeSpan timespan)
	{
		return Observable.Generate(0, i => true, i => ++i, i => i, i => i==0?duePeriod:timespan);
	}

	public static IObservable<int> Interval(TimeSpan timespan)
	{
		return Observable.Generate(0, i => true, i => ++i, i => i, i => timespan);
	}
}