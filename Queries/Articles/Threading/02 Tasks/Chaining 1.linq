<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

ILog logger = LogManager.GetLogger("Main");

void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info(nameof(Main));

	Task taskOne = new Task( new Action(TaskOneFunction));
	
	taskOne.ContinueWith( new Action<Task>(TaskTwoFunctionWrapper));
	
	taskOne.Start();
}

public void TaskOneFunction()
{
	logger.Info(nameof(TaskOneFunction));
}

public void TaskTwoFunction()
{
	logger.Info(nameof(TaskTwoFunction));
}

public void TaskTwoFunctionWrapper(Task antecedent)
{
	TaskTwoFunction();
}