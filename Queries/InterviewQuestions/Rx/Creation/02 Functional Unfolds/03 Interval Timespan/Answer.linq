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

	// Question: Generate a sequence of 5 integers, each of which
	// will be delivered in 1 second intervals
	Observable
	.Interval(TimeSpan.FromSeconds(1))
	.Take(5)
	.Subscribe(o => WriteLine($"OnNext({o})"),()=>WriteLine("OnCompleted()"));
}