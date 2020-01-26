<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<(string,string)>(("014","5"),IntegerLongDivision("145",10));
}

// Question : Implement the below to parse an integer string
public int ParseInteger(string s) => throw new NotImplementedException();


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