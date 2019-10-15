<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(2,Subtract(5,3));
	MyExtensions.AreEqual<sbyte>(6,Subtract(5,-1));
}

// Implement subtact without the - key
public sbyte Subtract(sbyte a, sbyte b) => throw new NotImplementedException();