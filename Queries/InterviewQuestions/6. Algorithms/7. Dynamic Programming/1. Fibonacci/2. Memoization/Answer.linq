<Query Kind="Program" />

void Main()
{
	//	MyExtensions.AreEqual(0, FibonacciRecursive(0));
	//	MyExtensions.AreEqual(1, FibonacciRecursive(1));
	//	MyExtensions.AreEqual(1, FibonacciRecursive(2));
	//	MyExtensions.AreEqual(2, FibonacciRecursive(3));
	//	MyExtensions.AreEqual(3, FibonacciRecursive(4));
	//	MyExtensions.AreEqual(5, FibonacciRecursive(5));
	//	MyExtensions.AreEqual(8, FibonacciRecursive(5));
	count=0;
	MyExtensions.AreEqual(144, FibonacciRecursive(12));
}
 int count;

// Question: Implement Recursive Fibonacci and use Memoization to improve perf
public  int FibonacciRecursive(int x)
{

	var cache = new int[x + 1];

	int F(int x1)
	{
		count++;
		if (x1 == 0 || x1 == 1) return x1;

		if (cache[x1] == 0)
			cache[x1] = F(x1 - 1) + F(x1 - 2);

		return cache[x1];
	}

	return F(x);
}