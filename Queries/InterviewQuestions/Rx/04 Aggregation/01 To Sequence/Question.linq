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


	// 2. Min
	WriteLine();

	// 3. Max
	WriteLine();

	// 4. Sum
	WriteLine();

	// 5. Average
	WriteLine();

}