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
	Action c = () => Console.WriteLine("Done");
	Action<int> e = v=> Console.WriteLine(v);

	// 1. Where
	Observable.Range(0,10)
		.Where(o => o%2==0)
		.Subscribe(e,c);

	// 2. Distinct
	WriteLine();

	// 3. DistinctUntilChanged
	WriteLine();

	// 4. IgnoreElements
	WriteLine();

	// 5. Skip
	WriteLine();

	// 6. Take
	WriteLine();

	// 7 SkipWhile
	WriteLine();

	// 8 TakeWhile
	WriteLine();

	// 9. SkipUntil a value is produced by another source
	WriteLine();

	// 10. TakeUntil
	WriteLine();
}