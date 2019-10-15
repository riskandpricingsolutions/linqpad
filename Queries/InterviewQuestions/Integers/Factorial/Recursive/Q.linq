<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(0, Factorial(0));
	MyExtensions.AreEqual(1, Factorial(1));
	MyExtensions.AreEqual(1, Factorial(2));
	MyExtensions.AreEqual(2, Factorial(3));
	MyExtensions.AreEqual(3, Factorial(4));
}

// Question: Implement Recursive Factorial
public static int Factorial(int x) => throw new NotImplementedException();