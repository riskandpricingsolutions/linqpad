<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Activities.dll</Reference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Activities.Statements</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	// Question: Give examples of all the following
	Observable
		.Range(0,3)
		.Aggregate ((x, y) => x+y)
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()")); ;

	Observable
		.Range(0, 3)
		.Scan(10,(x, y) => x + y)
	.	Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()")); ;
}