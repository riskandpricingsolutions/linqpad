<Query Kind="Program" />

void Main()
{

	MyExtensions.AreEqual(false, IsPrime(1));
	MyExtensions.AreEqual(true, IsPrime(2));
	MyExtensions.AreEqual(true, IsPrime(3));
	MyExtensions.AreEqual(false, IsPrime(4));
	MyExtensions.AreEqual(true, IsPrime(5));
}

// Question: Write a super naive implementation of IsPrime
public static bool IsPrime(int x) => throw new NotImplementedException();