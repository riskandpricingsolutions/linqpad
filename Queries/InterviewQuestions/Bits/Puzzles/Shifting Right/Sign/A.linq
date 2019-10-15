<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(-1, GetSign(-5));
	MyExtensions.AreEqual<sbyte>(0, GetSign(0));
	MyExtensions.AreEqual<sbyte>(0, GetSign(5));

	MyExtensions.AreEqual<sbyte>(-1, GetSign2(-5));
	MyExtensions.AreEqual<sbyte>(1, GetSign2(0));
	MyExtensions.AreEqual<sbyte>(1, GetSign2(5));
}

// Question: Write code to return the sign of an integer
//           without using branching. Return -1 if the 
//           number is negative, otherwise 0
public sbyte GetSign(sbyte a) => (sbyte)(a >> ((sizeof(sbyte) * 8)-1));

// Question: Write code to return the sign of an integer
//           without using branching. Return -1 if the 
//           number is negative, otherwise 1
public sbyte GetSign2(sbyte a) => (sbyte)(1 |(a >> ((sizeof(sbyte) * 8)-1)));
