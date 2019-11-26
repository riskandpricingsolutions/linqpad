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

	// Question: Generate sequence of integers. The first will be
	// delivered after 3 seconds and subsequent integers will be delivered
	// in 1 second intervals. In total we should see five values from 0..4
	Observable.Timer(TimeSpan.FromSeconds(3),TimeSpan.FromSeconds(1))
	.Take(5)
	.Subscribe(o => WriteLine($"OnNext({o})"),()=>WriteLine("OnCompleted()"));
}