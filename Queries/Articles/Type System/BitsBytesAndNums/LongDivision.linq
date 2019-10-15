<Query Kind="Program" />

void Main()
{
	'f'.ToIntDigit().Dump();
	
	10.ToChar().Dump();
	
	var result = IntegerLongDivision("1",3,10);
}

private (string quotient, string remainder) IntegerLongDivision(string dividend, int divisor, int b = 10)
{
	StringBuilder quotient = new StringBuilder();
	int remainder = 0;
	int dd = 0;

	for (int idx = 0; idx < dividend.Length; idx++)
	{
		// idx.1 copy in next digit into temporary dividend dd
		dd = (dd * b) + dividend[idx].ToIntDigit();

		// idx.2 calculate partial quotient and set into quotient[idx] 
		int partialQuotient = dd / divisor;
		quotient.Append(partialQuotient.ToChar());

		// idx.3 calculate this temporary as part of calculating remainder
		int temp = partialQuotient * divisor;

		// idx.4 Calculate the remainder
		remainder = dd % divisor;

		// the remainder will form the basis of dd[idx+1]
		dd = remainder;
	}

	return (quotient.ToString(), remainder.ToChar().ToString());
}

public string IntegerDivisionWithFloatingPointResult(string dividend, int divisor, 
	int b = 10, int maxDigits = 8)
{
	StringBuilder quotient = new StringBuilder();
	int remainder = 1;
	int dd = 0;

	for (int idx = 0; (idx < dividend.Length || remainder > 0) 
			&& idx < maxDigits; idx++)
	{
		// Add in a decimal point
		if (idx == dividend.Length)
			quotient.Append(".");

		// idx.1 copy in next digit into temporary dividend dd
		if (idx < dividend.Length)
			dd = (dd * b) + dividend[idx].ToIntDigit();
		else
			// The integer dividend has no more digits so we just increase 
			// by a factor of b as we move to the right side of the point
			// point
			dd = (dd * b);

		// idx.2 calculate partial quotient and set into quotient[idx] 
		int partialQuotient = dd / divisor;
		quotient.Append(partialQuotient.ToChar());

		// idx.3 calculate this temporary as part of calculating remainder
		int temp = partialQuotient * divisor;

		// idx.4 Calculate the remainder
		remainder = dd % divisor;

		// the remainder will form the basis of dd[idx+1]
		dd = remainder;
	}

	return quotient.ToString();
}

public static class Extensions
{
	public static int ToIntDigit(this char c)
	{
		if (char.IsNumber(c)) return (int)char.GetNumericValue(c);

		return (int)(char.ToLower(c) - 'a' + 10);
	}
	
	public static char ToChar(this int i)
	{
		if ( i >= 0  && i < 10)
			return (char)(i + '0');
		
		return (char)(i + 'a' -10);
	}
}