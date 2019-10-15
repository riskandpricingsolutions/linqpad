<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(5, Max(5, 2));
	MyExtensions.AreEqual<sbyte>(5, Max(2, 5));
	MyExtensions.AreEqual<sbyte>(2, Max(-5, 2));
	MyExtensions.AreEqual<sbyte>(2, Max(2, -5));
}

// Question: Write code to calculate the maxium of two integers 
// -------- without using framework methods and branching constructs
public sbyte Max(sbyte a, sbyte b) => throw new NotImplementedException();