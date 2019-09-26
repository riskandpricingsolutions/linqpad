<Query Kind="Program" />


void Main()
{
	MyExtensions.AreEqual("345.0",ChangeBase("345.0",10,10));
	MyExtensions.AreEqual("11111.0",ChangeBase("31.0",10,2));
	MyExtensions.AreEqual("ff.0",ChangeBase("255.0",10,16));
	MyExtensions.AreEqual("345.45",ChangeBase("345.45",10,10));
	MyExtensions.AreEqual("345.45",ChangeBase("345.45",10,10));
	MyExtensions.AreEqual("0.1",ChangeBase("0.5",10,2));
	MyExtensions.AreEqual("0.5",ChangeBase("0.1",2,10));
}

public string ChangeBase(string input, int sourceBase, int targetBase)
{
	var parts = input.Split('.');
	var integralPart = ConvertIntegralPart(parts[0], sourceBase, targetBase);
	var fractionalPart = ConvertFractionalPart(parts[1], sourceBase, targetBase);

	return integralPart + "." + fractionalPart;
}
private string ConvertIntegralPart(string input, int bIn, int bOut)
{
	// Convert the input to a decimal integer
	long decimalInput = input[0].ToIntDigit();
	for (var i = 1; i < input.Length; i++)
		decimalInput = decimalInput * bIn + input[i].ToIntDigit();

	// Setup an array of the correct size for the output
	char[] result = new char[Extensions.NumDigits(decimalInput, bOut)];

	// Keep track of the quotient.
	long quotient = decimalInput;
	int idx = 0;

	do
	{
		long r = quotient % bOut;
		quotient = quotient / bOut;

		result[result.Length - idx - 1] = ((int)r).ToChar();
		idx++;

	} while (quotient > 0);

	return new string(result);
}

private string ConvertFractionalPart(string fractionalPart, int bIn, int bOut)
{
	StringBuilder result = new StringBuilder();
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


