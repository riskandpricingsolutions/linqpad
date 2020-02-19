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

	// 1. Count
	Observable.Range(0,5)
		.Count()
		.Subscribe(c=>WriteLine(c));


	// 2. Min
	new int[] {4,5,7,8,1}
		.ToObservable()
		.Min()
		.Subscribe(c => WriteLine(c));

	WriteLine();

	// 3. Max
	WriteLine();

	// 4. Sum
	WriteLine();

	// 5. Average
	WriteLine();

}