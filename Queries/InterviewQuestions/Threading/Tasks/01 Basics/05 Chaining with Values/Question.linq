<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Question: The first unit of work returns a value needed by the second 
	//           write code to deal with this	
	
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