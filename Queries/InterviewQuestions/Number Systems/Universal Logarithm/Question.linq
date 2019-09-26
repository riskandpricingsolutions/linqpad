<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<double>(3.0,UniveralLogarithm(8.0,2.0));
	MyExtensions.AreEqual<double>(4.0,UniveralLogarithm(10000.0,10.0));
	MyExtensions.AreEqual<double>(2.0,UniveralLogarithm(256.0,16.0));
	MyExtensions.AreEqual<double>(1,UniveralLogarithm(Math.E,Math.E));
}


// Question: Implement the universal logarithm function
public double UniveralLogarithm(double x, double b)
{
	throw new NotSupportedException();
}