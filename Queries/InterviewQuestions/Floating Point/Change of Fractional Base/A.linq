<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual("0.1", ConvertFractionalPart("0.5", 10, 2));
	MyExtensions.AreEqual("0.5", ConvertFractionalPart("0.1", 2, 10));
	MyExtensions.AreEqual("0.75", ConvertFractionalPart("0.11", 2, 10));
	MyExtensions.AreEqual("0.00011001", ConvertFractionalPart("0.1", 10, 2,8));}


private string ConvertFractionalPart(string input, int l, int b, 
	int maxDigits=16)
{	
	var fractionString = input.Split('.')[1];
	var result = new StringBuilder("0.");

	// Calculate the decimal Fraction
	double decimalFraction = 0.0;
	for (int i = 0; i < fractionString.Length; i++)
	{
		decimalFraction += 
			fractionString[i].ToIntDigit() * Math.Pow(l,-(i+1));		
	}	
		
	int digitIdx=0;
	while (decimalFraction > 0.0 && digitIdx++ < maxDigits)
	{
		decimalFraction = (decimalFraction * b);
		int digit = (int)decimalFraction;
		result.Append(digit.ToChar());

		decimalFraction -= digit;		
	}
	
	return result.ToString();
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

	public static double Log(double x, int b) => Math.Log(x) / Math.Log(b);

	public static int NumDigits(long decimalInput, int b) =>
		(decimalInput == 0) ? 1 : (int)Math.Ceiling(Log(decimalInput + 1, b));
}