<Query Kind="Program" />

// Question Write an iterator to calculate the first n elements
// of the fibonacci series
IEnumerable<int> GetFibonacci(int numEntries) 
{

}

void Main()
{
	IEnumerable<int> fib5 = GetFibonacci(5);
	foreach (var element in fib5)
	{
		Console.WriteLine(element);
	}
}