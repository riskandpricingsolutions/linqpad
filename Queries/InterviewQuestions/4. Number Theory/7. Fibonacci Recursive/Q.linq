<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(0, FibonacciRecursive(0));
	MyExtensions.AreEqual(1, FibonacciRecursive(1));
	MyExtensions.AreEqual(1, FibonacciRecursive(2));
	MyExtensions.AreEqual(2, FibonacciRecursive(3));
	MyExtensions.AreEqual(3, FibonacciRecursive(4));
}

// Question: Implement Recursive Fibonacci
public static int FibonacciRecursive(int x) 
{
	if (x==0) return 0;
	if (x==1) return 1;
	
	return (FibonacciRecursive(x-1)+FibonacciRecursive(x-2));
}