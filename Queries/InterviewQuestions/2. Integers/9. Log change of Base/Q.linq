<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(3,Log(8,2));
	MyExtensions.AreEqual(2,Log(100,10));
	MyExtensions.AreEqual(3,Log(27,3));
}

// Question: Write a function to calculate log in any base
public double Log(double x, double b) => Math.Log(x) / Math.Log(b);