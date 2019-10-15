<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<bool>(false, IsPowerOfTwo(0));
	MyExtensions.AreEqual<bool>(false, IsPowerOfTwo(1));
	MyExtensions.AreEqual<bool>(true, IsPowerOfTwo(2));
	MyExtensions.AreEqual<bool>(true, IsPowerOfTwo(3));
	MyExtensions.AreEqual<bool>(true, IsPowerOfTwo(4));
	MyExtensions.AreEqual<bool>(true, IsPowerOfTwo(5));
	
}

// Question: Write code to determimne if a integer is a power of 2
// -------- 
public bool IsPowerOfTwo(int a) => throw new NotImplementedException();