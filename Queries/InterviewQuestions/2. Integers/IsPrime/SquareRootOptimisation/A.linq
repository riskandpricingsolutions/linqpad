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
public bool IsPrimeUsingSquareRoot(int n)
{
	if (n < 2)
		return false;

	if (n == 2)
		return true;

	// The definition of a prime is an integer x
	// which is not exactly divisible by any 
	// number other than itself and one. If a 
	// number x is not prime it can be written as 
	// the product of two factors a x b. If both 
	// a and b were greater than the square root of 
	// x then a x b would also be greater than x and hence 
	// a x b is not x. SO testing all factors up to floor(root(x))
	// is sufficient as if one factor is floor(root(x)) the other factor must
	// be less than that

	// hence test the n-2 integers from 
	// 2,..., Floor(Root(N))
	return Enumerable.Range(2, (int)Math.Floor(Math.Sqrt(n)))
		.All(i => n % i > 0);
}
