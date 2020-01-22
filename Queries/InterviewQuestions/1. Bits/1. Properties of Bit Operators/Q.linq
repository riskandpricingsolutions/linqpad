<Query Kind="Program" />

void Main()
{
	sbyte a =  unchecked((sbyte)0b11010101);
		
	// a ^ 0s

	MyExtensions.AreEqual<sbyte>(sbyte.MinValue,(sbyte)(a ^ 0));

	// a ^ 1s
	MyExtensions.AreEqual<sbyte>(sbyte.MinValue, (sbyte)(a ^ ~0));
	
	// a ^ a
	MyExtensions.AreEqual<sbyte>(sbyte.MinValue, (sbyte)(a ^ a));	
	
	// a & 0s
	MyExtensions.AreEqual<sbyte>(sbyte.MinValue, (sbyte)(a & 0));	
	
	// a & 1s
	MyExtensions.AreEqual<sbyte>(sbyte.MinValue, (sbyte)(a & ~0));
	
	// a & a
	MyExtensions.AreEqual<sbyte>(sbyte.MinValue, (sbyte)(a & a));

	// a | 1s
	MyExtensions.AreEqual<sbyte>(sbyte.MinValue, (sbyte)(a | ~0));

	// a | a
	MyExtensions.AreEqual<sbyte>(sbyte.MinValue, (sbyte)(a | a));

	// a ^ ~a
	MyExtensions.AreEqual<sbyte>(sbyte.MinValue, (sbyte)(a ^ ~a));
}