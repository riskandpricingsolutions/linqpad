<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(8,Add(5,3));
	MyExtensions.AreEqual<sbyte>(4,Add(5,-1));
}

public sbyte Add(sbyte a, sbyte b) => throw new NotImplementedException();