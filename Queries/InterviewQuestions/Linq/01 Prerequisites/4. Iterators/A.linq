<Query Kind="Program" />

// Question Write an iterator to calculate the first n elements
// of the fibonacci series
IEnumerable<int> GetFibonacci(int numEntries) 
{
	for (int i=0, current=0,next=1; i < numEntries;i++)
	{
		yield return current;
		int temp  = current+next;
		current = next;
		next = temp;
	}
}

void Main()
{
	IEnumerable<int> fib5 = GetFibonacci(5);
	foreach (var element in fib5)
	{
		Console.WriteLine(element);
	}
}