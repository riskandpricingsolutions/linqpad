<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	// Question: Give examples of all the following


	Observable.Interval(TimeSpan.FromMilliseconds(500))
		.Take(4)
		.Timeout(TimeSpan.FromSeconds(0.4), Observable.Range(10,5).Select(o => (long)o))
		.Subscribe(o => WriteLine($"OnNext({o})"), (e) => WriteLine($"OnError({e})"),() => WriteLine($"OnCompleted()"));
	


	
}