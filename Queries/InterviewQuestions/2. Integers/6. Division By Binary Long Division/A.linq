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
		// Get the value of the dividend's bit at index i
		byte dividend_i = (byte)((dividend >> i) & 1);
		 
		// Form the temporary dividend for this iteration by 
		// combining the remainder from the previous 
		// step (shifted one place left) 
		int temp_dividend_i =  ((remainder << 1) | dividend_i);

		// The value of the quotient at index i can only be 1 or 0. 
		// It is 1 if the divisor is greater than or equal to  
		// temp_dividend_i, otherwise it is zero
		int quotient_i = (((temp_dividend_i >= divisor) ? 1 : 0) << i);

		// copy quotient_i into the quotient
		quotient |= quotient_i;


		//int productTemp = quotient_i * divisor
		int productTemp = quotient_i * divisor;
		

		// Shift the remainder left by 1 bit and add in the 
		// bit i from the dividend
		remainder = ((remainder << 1) | dividend_i);
		

		

		// If the quotient digit q_i is non zero we subtract the 
		// divisor fro, the dividendTemp
		if ( quotient_i > 0 )
			remainder -= divisor;
	}
	
	return (quotient,remainder);
}