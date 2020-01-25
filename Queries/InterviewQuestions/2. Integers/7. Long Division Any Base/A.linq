<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<(string,string)>(("014","5"),IntegerLongDivision("145",10));
}

// Question : Implement the below to perform integer long division in any base.
public (string quotient, string remainder) IntegerLongDivision(string dividend, int divisor,
	int b = 10)
{
	StringBuilder quotient = new StringBuilder();
	int remainder = 0;
	int dd = 0;

	for (int idx = 0; idx < dividend.Length; idx++)
	{
		// Get the value of the character at index i and 
		// convert it to an integer. This gives us a single
		// digit of the dividend
		int dividend_i = dividend[idx].ToIntDigit();
		
		// Form the partial dividend for this iteration my 
		// shifting the remainder from the previous iteration 
		// one position left and adding the dividend[i]
		int partialDividend_i = (remainder * b) + dividend_i;

		// Calculate partial quotient and set into quotient[idx] 
		int quotient_i = partialDividend_i / divisor;
		quotient.Append(quotient_i.ToChar());

		// Calculate the remainder
		remainder = partialDividend_i % divisor;
	}

	return (quotient.ToString(), remainder.ToChar().ToString());
}

public static class Extensions
{
	public static int ToIntDigit(this char c)
	{
		if (char.IsNumber(c)) return (int)char.GetNumericValue(c);

		return char.ToLower(c) - 'a' + 10;
	}

	public static char ToChar(this int i)
	{
		if (i >= 0 && i < 10)
			return (char)(i + '0');

		return (char)(i + 'a' - 10);
	}
}