<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(2, Min(5, 2));
	MyExtensions.AreEqual<int>(2, Min(2, 5));
	MyExtensions.AreEqual<int>(-5, Min(-5, 2));
	MyExtensions.AreEqual<int>(-5, Min(2, -5));
}

// Question: Write code to calculate the minimum of two integers 
// -------- without using framework methods and branching constructs
public int Min(int a, int b) 
{
	// If a >=b diff is 0xxx otherwise it is 1xxx
	int diff = a-b;
	
	// If a >=b shifted is 0000... otherwise it is 1111...
	int shifted = diff >> (sizeof(int) * 4)-1;
	

	// If a >= b anded is 0000. If b>a anded is (a-b)
	int anded = diff & shifted;
	
	// If we now add back b we get a if a < b and b if b<a
	// definition of min
	return anded + b;
}