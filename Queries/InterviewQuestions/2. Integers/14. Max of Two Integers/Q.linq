<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(5, Max(5, 2));
	MyExtensions.AreEqual<int>(5, Max(2, 5));
	MyExtensions.AreEqual<int>(2, Max(-5, 2));
	MyExtensions.AreEqual<int>(2, Max(2, -5));
}

// Question: Write code to calculate the maxium of two integers 
// -------- without using framework methods and branching constructs
public int Max(int a, int b) 
{
	// If a >= b then diff is 0xxx. If b > a then diff is 1xxx
	int diff = a - b;
	
	int shift = diff >> ((sizeof(int)*4)-1);
	
	
}