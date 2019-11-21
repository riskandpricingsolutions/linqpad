<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Question: Show the exact types of the function used to execute TaskOneFunction
	//           as antecedent and TaskTwoFunction as a continuation	
}

public void TaskOneFunction()
{
	Console.WriteLine(nameof(TaskOneFunction));
}

public void TaskTwoFunction()
{
	Console.WriteLine(nameof(TaskTwoFunction));
}

public void TaskTwoFunctionWrapper(Task antecedent)
{
	TaskTwoFunction();
}

