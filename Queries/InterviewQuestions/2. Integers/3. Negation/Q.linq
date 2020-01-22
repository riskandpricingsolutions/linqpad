<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(10,Negate(-10));
	MyExtensions.AreEqual<int>(-5,Negate(5));
}

// Implement sNegation
public int Negate(int b) => ~b+1;