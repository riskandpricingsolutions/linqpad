<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<double>(90, LowestCommonMultiple(18, 15));
}


// Question: Calculate LCM
public double LowestCommonMultiple(int a, int b) => a * b / HighestCommonFactor(a,b);

public int HighestCommonFactor(int a, int b)
{
	if (a<b) return HighestCommonFactor(b,a);
	
	int remainder = a %b;
	
	if (remainder ==0 ) return b;
	
	return HighestCommonFactor(b,a%b);
}