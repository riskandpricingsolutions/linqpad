<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual("0.11",ConvertIntegralPart(0.75,8));
	MyExtensions.AreEqual("0.00011001",ConvertIntegralPart(0.1,8));
}


private string ConvertIntegralPart(double b, int maxDigits) 
{
	StringBuilder result = new StringBuilder("0.");
	if (b >= 1.0) throw new ArgumentException("Input must be a fraction");
	
	double frac = 0.5;
	
	
	while (b >=0 && maxDigits-- > 0)
	{
		if (b >=frac)
		{
			result.Append("1");
			b-= frac;
		}
		else
		{
			result.Append("0");
		}

		frac /= 2;
	}
	
	return result.ToString();
}



