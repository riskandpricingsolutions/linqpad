<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(5, AbsoluteValue(5));
	MyExtensions.AreEqual<sbyte>(5, AbsoluteValue(-5));
}

// Question: Write code to calculate the absolute value
// -------- of an integer
public sbyte AbsoluteValue(sbyte x)
{ 
	sbyte mask = (sbyte)(x >> 7);
	return (sbyte)((mask ^ x ) - mask);
}
