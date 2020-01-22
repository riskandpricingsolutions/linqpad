<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(0, FibonacciRecursive(0));
	MyExtensions.AreEqual(1, FibonacciRecursive(1));
	MyExtensions.AreEqual(1, FibonacciRecursive(2));
	MyExtensions.AreEqual(2, FibonacciRecursive(3));
	MyExtensions.AreEqual(3, FibonacciRecursive(4));
}

// Question: Implement Recursive Binary Search
public static int FibonacciRecursive(int n)
{
	if (n == 0)
		return 0;
	if (n == 1)
		return 1;

	return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
}



