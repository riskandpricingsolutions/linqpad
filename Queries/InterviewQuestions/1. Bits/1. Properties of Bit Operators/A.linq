<Query Kind="Program" />

void Main()
{
	sbyte a =  unchecked((sbyte)0b11010101);
		
	// a ^ 0s

	MyExtensions.AreEqual<sbyte>(a,(sbyte)(a ^ 0));

	// a ^ 1s
	MyExtensions.AreEqual<sbyte>((sbyte)~a, (sbyte)(a ^ ~0));
	
	// a ^ a
	MyExtensions.AreEqual<sbyte>((sbyte)0, (sbyte)(a ^ a));	
	
	// a & 0s
	MyExtensions.AreEqual<sbyte>((sbyte)0, (sbyte)(a & 0));	
	
	// a & 1s
	MyExtensions.AreEqual<sbyte>((sbyte)a, (sbyte)(a & ~0));
	
	// a & a
	MyExtensions.AreEqual<sbyte>((sbyte)a, (sbyte)(a & a));

	// a | 1s
	MyExtensions.AreEqual<sbyte>((sbyte)~0, (sbyte)(a | ~0));

	// a | a
	MyExtensions.AreEqual<sbyte>((sbyte)a, (sbyte)(a | a));

	// a ^ ~a
	MyExtensions.AreEqual<sbyte>((sbyte)~0, (sbyte)(a ^ ~a));
}


