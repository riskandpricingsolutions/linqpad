<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

async void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info("Main() started");	

	AnAwaitableType<double> awaitable = 
		new AnAwaitableType<double>(100.0);
	
	AwaiterImplementation<double> awaiter = awaitable.GetAwaiter();
	awaiter.OnCompleted(() =>
	{
		logger.Info($"{awaiter.GetResult()}");
    });
}

public class AnAwaitableType<T>
{
	public AnAwaitableType(T value) => _value = value;
	
	public AwaiterImplementation<T> GetAwaiter() => 
		new AwaiterImplementation<T>(_value);
	
	private T _value;
}

public class AwaiterImplementation<TResult> : INotifyCompletion
{
	public AwaiterImplementation(TResult value) => _value = value;
	
	public bool IsCompleted => true;

	public void OnCompleted(Action continuation) => continuation();
	
	public TResult GetResult() => _value;
	
	private TResult _value;
}