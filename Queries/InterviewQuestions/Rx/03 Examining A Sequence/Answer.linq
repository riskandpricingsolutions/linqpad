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

	// 1. Any
	WriteLine();
	Observable
		.Range(0,10)
		.Any(o => o==5)
		.Subscribe(o => WriteLine($"OnNext({o})"),()=>WriteLine("OnCompleted()"));

	Observable
		.Empty<int>()
		.Any()
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()"));

	// 2. All
	WriteLine();
	Observable
		.Range(10,5)
		.All(i=>i>=5)
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()"));

	// 3. Contains
	WriteLine();
	WriteLine();
	Observable
		.Range(0, 10)
		.Contains(5)
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()"));

	// 4. DefaultIfEmpty
	WriteLine();
	Observable
		.Empty<int>()
		.DefaultIfEmpty()
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()"));

	// 5. ElementAt
	WriteLine();
	Observable
		.Range(0, 10)
		.Select(x=>x*x)
		.ElementAt(1)
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()"));

	// 6. SequenceEqual
		WriteLine();
	Observable
		.Range(0, 10)
		.SequenceEqual(Observable
		.Range(0, 10))
		.Subscribe(o => WriteLine($"OnNext({o})"),() => WriteLine("OnCompleted()"));
	WriteLine();
}