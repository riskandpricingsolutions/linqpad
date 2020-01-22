<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<(int,int)>((9/2,9%2),Divide(9,2));
	MyExtensions.AreEqual<(int,int)>((0/2,0%2),Divide(0,2));
	MyExtensions.AreEqual<(int,int)>((10/2,10%2),Divide(10,2));
	MyExtensions.AreEqual<(int,int)>((-10/2,-10%2),Divide(-10,2));
	MyExtensions.AreEqual<(int,int)>((-10/-2,-20%2),Divide(-10,-2));
	MyExtensions.AreEqual<(int,int)>((10/-2,10%-2),Divide(10,-2));
}

// Question: Write a method to perform the simplest possible signed integer
// --------- division algorithm using Euclids algorithm
public (int q, int r) Divide(int dividend, int divisor) 
{
	if (divisor ==0) throw new DivideByZeroException();
	
	if (dividend<0 && divisor < 0) return UnsignedDivide(-dividend,-divisor);

	if (dividend < 0)
	{
		(int q, int r)  = UnsignedDivide(-dividend,divisor);
		return (-q,r);
	}
	if (divisor < 0)
	{
		(int q, int r) = UnsignedDivide(dividend, -divisor);
		return (-q, r);
	}
	
	return UnsignedDivide(dividend,divisor);
}

private (int q, int r) UnsignedDivide(int dividend, int divisor)
{
	int remainder = dividend;
	int quotient = 0;
	
	while (remainder >= divisor)
	{
		remainder -= divisor;
		quotient++;
	}

	return (quotient, remainder);
}