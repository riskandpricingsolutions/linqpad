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

}