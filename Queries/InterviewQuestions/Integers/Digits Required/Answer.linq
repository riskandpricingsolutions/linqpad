<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<double>(4, DigitsRequired(1001, 10));
	MyExtensions.AreEqual<double>(5, DigitsRequired(16, 2));
}


// Question: Calculate the number of digits required to represent value x in base b
public double DigitsRequired(int x, int b) => Math.Ceiling(UniveralLogarithm(x+1,b));

public double UniveralLogarithm(double x, double b) => Math.Log(x) / Math.Log(b);