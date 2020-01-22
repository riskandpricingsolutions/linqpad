<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(0, FibonacciIterative(0));
	MyExtensions.AreEqual(1, FibonacciIterative(1));
	MyExtensions.AreEqual(1, FibonacciIterative(2));
	MyExtensions.AreEqual(2, FibonacciIterative(3));
	MyExtensions.AreEqual(3, FibonacciIterative(4));
}

// Question: Implement Iterative Fibonacci
public static int FibonacciIterative(int x) => throw new NotImplementedException();