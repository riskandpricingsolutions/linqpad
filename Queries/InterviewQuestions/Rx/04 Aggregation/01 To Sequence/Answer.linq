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

	// Question: Give examples of all the following

	// 1. Count
	Observable
		.Range(10,15)
		.Count()
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()"));;

	Observable
		.Range(0, 10)
		.Count(x => x > 5)
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()")); ;

	// 2. Min
	WriteLine();
	Observable
		.Range(10, 5)
		.Min()
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()")); ;

	// 3. Max
	WriteLine();
	Observable
		.Range(10, 5)
		.Max()
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()")); ;

	// 4. Sum
	WriteLine();
	Observable
		.Range(10, 5)
		.Sum()
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()")); ;

	// 5. Average
	WriteLine();
	Observable
		.Range(0, 10)
		.Average()
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()")); ;

}