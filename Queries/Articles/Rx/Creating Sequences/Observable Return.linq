<Query Kind="Program">
  <NuGetReference>log4net</NuGetReference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Appender</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>log4net.Layout</Namespace>
  <Namespace>log4net.Repository.Hierarchy</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	// Return
	Observable.Return("Hello World")
	.Subscribe(o => Console.WriteLine(o));
	
	// Range 
	Observable.Range(1,10)
		.Subscribe(o => Console.WriteLine(o));
	
}

// Define other methods and classes here
