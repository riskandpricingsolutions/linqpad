<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(0, FibonacciRecursive(0));
	MyExtensions.AreEqual(1, FibonacciRecursive(1));
	MyExtensions.AreEqual(1, FibonacciRecursive(2));
	MyExtensions.AreEqual(2, FibonacciRecursive(3));
	MyExtensions.AreEqual(3, FibonacciRecursive(4));
}

// Question: Implement Recursive Fibonacci and use Memoization to improve perf
public static int FibonacciRecursive(int x) 
{
	var cache = new int[x+1];
	
	int F(int x1)
	{
		if (x1==0 || x1==1) return x1;
		
		if (cache[x1]==0)
			cache[x1] = F(x1-1) + F(x1-2);
		
		return cache[x1];
	}
	
	return F(x);
}