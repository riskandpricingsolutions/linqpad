<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<(int, int)>((4, 1), Divide(9, 2));
	MyExtensions.AreEqual<(int, int)>((0, 0), Divide(0, 2));
	MyExtensions.AreEqual<(int, int)>((5, 0), Divide(10, 2));
	MyExtensions.AreEqual<(int, int)>((-5, 0), Divide(-10, 2));
	MyExtensions.AreEqual<(int, int)>((5, 0), Divide(-10, -2));
	MyExtensions.AreEqual<(int, int)>((-5, 0), Divide(10, -2));
}

// Question: Write a method to perform the simplest possible signed integer
// --------- division algorithm using Euclids algorithm.
//
// Note: This algorith is very slow as it is O(q) where q is the quotient
public (int q, int r) Divide(int dividend, int divisor)=> throw new NotImplementedException();