<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Question: The first unit of work returns a value needed by the second 
	//           write code to deal with this

	Task<int> antecedent = new Task<int>(new Func<int>(TaskOneFunction));
	
	Task<int> continuation = antecedent.ContinueWith(new Func<Task<int>,int>(
		(task) => TaskTwoFunction(task.Result)
	));
	
	antecedent.Start();
	int result = continuation.Result;
	Console.WriteLine(result);
}

public int TaskOneFunction()
{
	Console.WriteLine(nameof(TaskOneFunction));
	return 5;
}

public int TaskTwoFunction(int x)
{
	Console.WriteLine(nameof(TaskTwoFunction));
	return x * 2;
}
