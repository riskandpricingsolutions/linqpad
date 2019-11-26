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

	// Question: Transition from a delegate. Use both action and function delegate
	Action a = () => logger.Info("Action Delegate");
	Observable.Start (a)
	.Subscribe(o => logger.Info($"OnNext({o})"),()=>logger.Info("OnCompleted()"));

	Func<int> f = () => 5;
	Observable.Start(f)
	.Subscribe(o => WriteLine($"OnNext({o})"),() => logger.Info("OnCompleted()"));

}