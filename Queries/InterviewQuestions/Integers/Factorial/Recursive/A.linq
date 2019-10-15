<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(1, Factorial(0));
	MyExtensions.AreEqual(1, Factorial(1));
	MyExtensions.AreEqual(2, Factorial(2));
	MyExtensions.AreEqual(6, Factorial(3));
	MyExtensions.AreEqual(24, Factorial(4));
	MyExtensions.AreEqual(120, Factorial(5));
}

// Question: Implement Recursive Factorial
public static int Factorial(int x) 
{
	if (x ==0) return 1;	
	return x * Factorial(x-1);	
}