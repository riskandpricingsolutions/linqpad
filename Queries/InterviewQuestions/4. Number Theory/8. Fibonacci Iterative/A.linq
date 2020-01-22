<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(0, Fibonacci(0));
	MyExtensions.AreEqual(1, Fibonacci(1));
	MyExtensions.AreEqual(1, Fibonacci(2));
	MyExtensions.AreEqual(2, Fibonacci(3));
	MyExtensions.AreEqual(3, Fibonacci(4));
}

// Question: Implement Recursive Binary Search
public static int Fibonacci(int x){
	
	// f0 f1 f2 f3 f4
	// 0  1  1  2  3
	
	// fn = Fibonacci(n)
	// fn1 =Fibonacci(n+1)
	// fn2 = Fibonacci(n+2)
	int fn =0, fn1 = 1;
	
	for (int i=0; i < x; i++ )
	{
		int fn2 = fn + fn1;
		fn = fn1;
		fn1 = fn2;
	}
	
	return fn;
}