<Query Kind="Program">
  <NuGetReference>log4net</NuGetReference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Appender</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>log4net.Layout</Namespace>
  <Namespace>log4net.Repository.Hierarchy</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	WriteLine("Generate");
	// Observable.Range(int)
	Observable.Generate(
			0,
			i => i < 3,
			i => ++i,
			i => $"Value {i}",
			i => TimeSpan.FromSeconds(i))
		.Subscribe(WriteLine, () => WriteLine("OnCompleted\n"));

}

// Define other methods and classes here