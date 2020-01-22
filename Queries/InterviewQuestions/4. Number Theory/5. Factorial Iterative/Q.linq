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

// Question: Implement Iterative Factorial
public static int Factorial(int x) => throw new NotImplementedException();