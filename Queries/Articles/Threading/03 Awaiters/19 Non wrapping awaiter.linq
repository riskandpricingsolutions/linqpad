<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info("Main() started");	

	Task<double> task = GetSpotPrice();
	
	TaskAwaiter<double> awaiter = task.GetAwaiter();

	awaiter.OnCompleted(() =>
    {
		logger.Info(awaiter.GetResult());
    });
}

public class NonWrappingAwaiter<T> : INotifyCompletion
{
	public NonWrappingAwaiter(Task<T> task) => _task = task;

	public bool IsCompleted => _task.GetAwaiter().IsCompleted;

	public void OnCompleted(Action continuation) => _task.GetAwaiter().OnCompleted (continuation);

	public T GetResult() => _task.Result;
	
	private Task<T> _task;
}