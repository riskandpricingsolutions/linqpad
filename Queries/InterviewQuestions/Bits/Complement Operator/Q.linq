<Query Kind="Program" />

void Main()
{
	sbyte a =  unchecked((sbyte)0b11010101);
		
	MyExtensions.AreEqual<sbyte>((sbyte)~a,Complement(a));

}

// Question: Implement the ~ operator
public static sbyte Complement(sbyte a) => throw new NotImplementedException();