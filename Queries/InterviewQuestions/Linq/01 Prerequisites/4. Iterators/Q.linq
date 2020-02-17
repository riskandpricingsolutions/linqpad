<Query Kind="Program" />

// Question Write an iterator to calculate the first n elements
// of the fibonacci series
IEnumerable<int> GetFibonacci(int numEntries) 
{
	for (int current=0,next=1; current<numEntries; )
	{
		yield return current;
		int nextNext = next+current;
		current = next;
		next = nextNext;
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