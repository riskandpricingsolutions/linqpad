<Query Kind="Program" />

void Main()
{
		MyExtensions.AreEqual<(int, int)>((5, 0), Divide(15, 3));
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
		return UnsignedDivide((int)-dividend, (int)-divisor);

	if (dividend < 0)
	{
		(int q, int r) = UnsignedDivide((int)-dividend, divisor);
		return ((int)-q, r);
	}

	if (divisor < 0)
	{
		(int q, int r) = UnsignedDivide(dividend, (int)-divisor);
		return ((int)-q, r);
	}

	return UnsignedDivide(dividend, divisor);
}

public (int quotient, int remainder) UnsignedDivide(int dividend, int divisor)
{
	int numBits = sizeof(int) * 8;
	int quotient = 0;
	
	int remainder = 0;
	
	for (int i = numBits-1; i >= 0; i--)
	{
		// Get the value of the dividend's bit at index i
		int dividend_i = (int)((dividend >> i) & 1);
		 
		// Form the partial dividend for this iteration 
		// (partialDividend[i]) by combining the bit 
		// at index i in the dividend (dividend[i])  
		// the remainder from the previous iteration 
		// shifted one bit left
		int partialDividend_i = (remainder << 1) | dividend_i;

		// The value of the quotient at index i (quotient[i]) 
		// can only be 1 or 0. It is 1 if the divisor is 
		// greater than or equal to  partialDividend[i], 
		//otherwise it is zero
		int quotient_i = ((partialDividend_i >= divisor) ? 1 : 0);

		// copy quotient[i] into the quotient
		quotient |= quotient_i <<i;

		// Calculate the product of quotient[i] and the divisor 
		// as a part of calculating the remainder
		int productTemp = quotient_i * divisor;
		
		// The remainder from this iteration is then the
		// partialDividend[i] - (quotient_i * divisor) = 
		//		partialDividend[i] % divisor
		remainder = partialDividend_i - productTemp;
		
		// Note the previous two statements can be much 
		// simplified in the case of binary
		// which we do in Answer2
	}
	
	return (quotient,remainder);
}