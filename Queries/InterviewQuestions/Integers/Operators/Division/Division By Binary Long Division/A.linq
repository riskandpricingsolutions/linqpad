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
public (int q, int r) Divide(int dividend, int divisor)
{
	if (divisor == 0) throw new DivideByZeroException();

	if (dividend < 0 && divisor < 0)
		return UnsignedDivide(-dividend, -divisor);

	if (dividend < 0)
	{
		(int q, int r) = UnsignedDivide(-dividend, divisor);
		return (-q, r);
	}

	if (divisor < 0)
	{
		(int q, int r) = UnsignedDivide(dividend, -divisor);
		return (-q, r);
	}

	return UnsignedDivide(dividend, divisor);
}

public (int quotient, int remainder) UnsignedDivide(int dividend, int divisor)
{
	int numBits = sizeof(byte) * 8;
	int quotient = 0;
	
	int remainder = 0;
	
	for (int i = numBits-1; i >= 0; i--)
	{
		// Get the value of the dividend's bit index i
		byte d_i = (byte)((dividend >> i) & 1);
		 
		// Shift the remainder left by 1 bit and add in the 
		// bit i from the dividend
		remainder = ((remainder << 1) | d_i);
		
		// The value of the quotient at index i can only be 1 or 0. 
		// It is 1 if the divisor is greater than or equal to  
		// remainder, otherwise it is zero
		int q_i = (((remainder >= divisor) ? 1 : 0) << i);
		
		// copy q_i into the quotient
		quotient |= q_i;
		
		// If the quotient digit q_i is non zero we subtract the 
		// divisor fro, the dividendTemp
		if ( q_i > 0 )
			remainder -= divisor;
	}
	
	return (quotient,remainder);
}