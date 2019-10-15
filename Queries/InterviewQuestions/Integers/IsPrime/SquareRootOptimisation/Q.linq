<Query Kind="Program" />

void Main()
{

	MyExtensions.AreEqual(false, IsPrimeUsingSquareRoot(1));
	MyExtensions.AreEqual(true, IsPrimeUsingSquareRoot(2));
	MyExtensions.AreEqual(true, IsPrimeUsingSquareRoot(3));
	MyExtensions.AreEqual(false, IsPrimeUsingSquareRoot(4));
	MyExtensions.AreEqual(true, IsPrimeUsingSquareRoot(5));
}

// Question: Write a is prime with square root optimisation
public static bool IsPrimeUsingSquareRoot(int x) => throw new NotImplementedException();