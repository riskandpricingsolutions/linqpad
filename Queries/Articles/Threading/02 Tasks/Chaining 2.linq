<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

ILog logger = LogManager.GetLogger("Main");

void Main()
{
	MyExtensions.SetupLog4Net();

	Task<int> taskOne = new Task<int>( new Func<int>(TaskOneFunction));
	
	Task<int> continuation =taskOne.ContinueWith( new Func<Task<int>,int>(TaskTwoFunctionWrapper));
	
	taskOne.Start();
	logger.Info(continuation.Result);
}


public int TaskOneFunction()
{
	logger.Info(nameof(TaskOneFunction));
	return 5;
}

public int TaskTwoFunction(int x)
{
	logger.Info(nameof(TaskTwoFunction));
	return x * 2;
}

public int TaskTwoFunctionWrapper(Task<int> antecedent)
{
	return TaskTwoFunction(antecedent.Result);
}