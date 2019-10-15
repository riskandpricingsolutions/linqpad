<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<bool>(false, IsPowerOfTwo(0));
	MyExtensions.AreEqual<bool>(true, IsPowerOfTwo(1));
	MyExtensions.AreEqual<bool>(true, IsPowerOfTwo(2));
	MyExtensions.AreEqual<bool>(false, IsPowerOfTwo(3));
	MyExtensions.AreEqual<bool>(true, IsPowerOfTwo(4));
	MyExtensions.AreEqual<bool>(false, IsPowerOfTwo(5));
	
}

// Question: Write code to determine if an integer is a power of 2
// -------- 
public bool IsPowerOfTwo(uint a) 
{
	return (a != 0) && (a & (a-1)) == 0;
}
