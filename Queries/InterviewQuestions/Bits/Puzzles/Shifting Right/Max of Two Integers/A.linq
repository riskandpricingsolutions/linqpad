<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(5, Max(5, 2));
	MyExtensions.AreEqual<sbyte>(5, Max(2, 5));
	MyExtensions.AreEqual<sbyte>(2, Max(-5, 2));
	MyExtensions.AreEqual<sbyte>(2, Max(2, -5));
		MyExtensions.AreEqual<sbyte>(1, Max(0, 1));
}

// Question: Write code to calculate the maximum of two integers 
// --------without using framework methods and branching constructs
public sbyte Max(sbyte a, sbyte b)
{
	// Take the differnce a-b. The result is one of two forms
	// a) 0xxxxxxx if a >= b
	// b) 1xxxxxxx if a < b
	sbyte difference = (sbyte)(a-b);

	// The result of the complemented right shift is 
	//  then one of two things
	// a) 11111111 if a >= b
	// b) 00000000 if a < b
	sbyte mask = (sbyte)~(difference >> (sizeof(sbyte)*8-1));

	// Now if we & the mask and (a-b) we get one of of two things
	// a) a-b      if a >= b
	// b) 0        if a < b
	sbyte temp = (sbyte)(mask & difference);

	// If we add b to this temp variable we get one of two things which
	// is what we wanted
	// a) a-b+b=a    if a >= b
	// b) 0+b=b      if a < b
	sbyte result = (sbyte)(temp + b);
	return result;
}