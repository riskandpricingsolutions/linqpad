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

	// 1. Any


	// 2. All
	WriteLine();

	// 3. Contains
	WriteLine();

	// 4. DefaultIfEmpty
	WriteLine();

	// 5. ElementAt
	WriteLine();

	// 6. SequenceEqual
	WriteLine();
}