<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<double>(3, HighestCommonFactor(18, 15));
}


// Question: Calculate HCF
// HCF(a,b) = HCF(b,a%b)
public double HighestCommonFactor(int a, int b) 
{
	if (a < b) return HighestCommonFactor(b,a);
	
	int remainder = a %b;
	
	if (remainder ==0) return b;
	
	return HighestCommonFactor(b,remainder);
}