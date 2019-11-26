<Query Kind="Program">
  <Namespace>log4net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	// Question: Write a simple awaiter that returns immediately

	AwaitableType<double> a = new AwaitableType<double>(100.0);
	var awaiter = a.GetAwaiter();
	
	awaiter.OnCompleted(() =>
   {
   		logger.Info(awaiter.GetValue());
   });
}

public class AwaitableType<TResult>
{
	private TResult _result ;
	public AwaitableType(TResult result) => _result = result;
	public AwaiterImplemenation<TResult> GetAwaiter() =>
		new AwaiterImplemenation<TResult>(_result);
}

public class AwaiterImplemenation<TResult> : INotifyCompletion
{
	private TResult _result;

	public AwaiterImplemenation(TResult result) =>_result = result;
	
	public void OnCompleted(Action continuation) => continuation();
	
	public bool IsCompleted => true;
	
	public TResult GetValue() => _result;
	
}