<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	Action doneAction = () => logger.Info("Completed");
	Action<int> nextAction = e => logger.Info(e);

	// Question: Create an empty observable of integers
	IObservable<int> observable = Observable.Empty<int>();
	
	observable.Subscribe(nextAction,doneAction);
	
}