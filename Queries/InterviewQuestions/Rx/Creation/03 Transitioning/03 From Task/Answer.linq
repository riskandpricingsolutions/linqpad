<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();


	// Question: Transition from a Task
	
	Task t = Task.Run (() => logger.Info("Task Running"));
	
	Task<double> t1 = Task.Run (() => 3.14);
		
	t1.ToObservable()
				.Subscribe(o => WriteLine($"OnNext({o})"),()=>WriteLine("OnCompleted()"));
	
}

