<Query Kind="Program" />

void Main()
{
	'f'.ToIntDigit().Dump();
	
	10.ToChar().Dump();
	
	var r1 = FractionalChangeOfBase("0.1111",2,10);
	var r2 = FractionalChangeOfBase("0.9375",10,2);

}

public static double Log(double x, int b) => Math.Log(x) / Math.Log(b);

public static int NumDigits(long decimalInput, int b) => (decimalInput ==0) ? 1 : (int)Math.Ceiling( Log(decimalInput+1,b));


private string FractionalChangeOfBase(string input, int bIn, int bOut)
{
	StringBuilder result = new StringBuilder("0.");
	var fractionalPart = input.Split('.')[1];
	var decimalFract = 0.0;

	for (int i = 0; i < fractionalPart.Length; i++)
		decimalFract += fractionalPart[i].ToIntDigit() * Math.Pow(bIn, -(i + 1));

		for (int i = 0; i < fractionalPart.Length; i++)
		{
			decimalFract *= bOut;
			int digit = (int)(decimalFract);
			result.Append(digit.ToChar());
			decimalFract -= digit;
		}

	return result.ToString();
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