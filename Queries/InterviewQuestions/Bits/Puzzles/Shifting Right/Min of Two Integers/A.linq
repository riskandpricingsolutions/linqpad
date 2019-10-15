<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(2, Min(5, 2));
	MyExtensions.AreEqual<sbyte>(2, Min(2, 5));
	MyExtensions.AreEqual<sbyte>(-5, Min(-5, 2));
	MyExtensions.AreEqual<sbyte>(-5, Min(2, -5));
}

// Question: Write code to calculate the minimum of two integers 
// -------- without using framework methods and branching constructs
public sbyte Min(sbyte a, sbyte b)
{
	// Take the differnce a-b. The result is one of two forms
	// a) 0xxxxxxx if a >= b
	// b) 1xxxxxxx if a < b
	sbyte difference = (sbyte)(a-b);

	// The result of the right shift is then one of two things
	// a) 00000000 if a >= b
	// b) 11111111 if a < b
	sbyte mask = (sbyte)(difference >> (sizeof(sbyte)*8-1));

	// Now if we & the mask and (a-b) we get one of of two things
	// a) 00000000 if a >= b
	// b) a-b      if a < b
	sbyte temp = (sbyte)(mask & difference);

	// If we add b to this temp variable we get one of two things which
	// is what we wanted
	// a) 0+b=b      if a >= b
	// b) a-b+b=a    if a < b
	sbyte result = (sbyte)(temp + b);
	return result;
}

// Define other methods and classes here