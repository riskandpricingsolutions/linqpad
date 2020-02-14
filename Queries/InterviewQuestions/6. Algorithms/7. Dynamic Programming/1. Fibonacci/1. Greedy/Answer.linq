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
	count =0;
	MyExtensions.AreEqual(144, FibonacciRecursive(12));
}
 int count;
// Question: Implement a Greedy Recursive Fibonnacci.
public  int FibonacciRecursive(int n)
{
	count++;
	if (n == 0)
		return 0;
	if (n == 1)
		return 1;

	return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
}