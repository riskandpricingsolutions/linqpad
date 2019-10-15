<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(2, Min(5, 2));
	MyExtensions.AreEqual<sbyte>(2, Min(2, 5));
	MyExtensions.AreEqual<sbyte>(-5, Min(-5, 2));
	MyExtensions.AreEqual<sbyte>(-5, Min(2, -5));
}

// Question: Write code to calculate the minimum of two integers 
// -------- without using framework methods and branching constructs
public sbyte Min(sbyte a, sbyte b) => throw new NotImplementedException();