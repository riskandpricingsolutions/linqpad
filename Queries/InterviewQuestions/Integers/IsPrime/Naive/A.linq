<Query Kind="Program" />

void Main()
{

	MyExtensions.AreEqual(false, IsPrimeNaive(1));
	MyExtensions.AreEqual(true, IsPrimeNaive(2));
	MyExtensions.AreEqual(true, IsPrimeNaive(3));
	MyExtensions.AreEqual(false, IsPrimeNaive(4));
	MyExtensions.AreEqual(true, IsPrimeNaive(5));
}

// Question: Write a super naive implementation of IsPrime. 
public static bool IsPrimeNaive(int n) 
{
	if (n <= 1) return false;
	
	for (int i = 2; i < n; i++)
	{
		if (n % i ==0)
			return false;
	}
	return true;
}

