<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual("345",ConvertIntegralPart("345",10,10));
	MyExtensions.AreEqual("3450",ConvertIntegralPart("3450",10,10));
	MyExtensions.AreEqual("11111",ConvertIntegralPart("31",10,2));
	MyExtensions.AreEqual("ff",ConvertIntegralPart("255",10,16));
	MyExtensions.AreEqual("345",ConvertIntegralPart("345",10,10));
}


private string ConvertIntegralPart(string input, int l, int b)
{	
	var result = new StringBuilder();
	
	// Calculate the decimal equivalent
	var idx =0;
	var d = input[idx].ToIntDigit();
	while(++idx < input.Length) d = (d * l) + input[idx].ToIntDigit();
	
	var quotient = d;
	do
	{
		var r = quotient % b ;
		quotient = quotient / b;
		result.Append(r.ToChar());
	}
	while (quotient > 0 );
	
	var chars = result.ToString().ToCharArray().Reverse().ToArray();
	return new string(chars);
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