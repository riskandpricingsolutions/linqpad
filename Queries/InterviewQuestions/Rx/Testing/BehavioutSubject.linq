<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Activities.dll</Reference>
  <NuGetReference>Microsoft.Reactive.Testing</NuGetReference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>Microsoft.Reactive.Testing</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Activities.Statements</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

var s1 = new BehaviorSubject<int>(1);
		
s1.Subscribe(o => WriteLine($"OnNext({o})"),()=>WriteLine("OnCompleted()"));
s1.OnCompleted();


