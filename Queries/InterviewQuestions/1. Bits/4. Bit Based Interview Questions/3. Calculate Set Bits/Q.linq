<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(0, BitCount(0));
	MyExtensions.AreEqual<int>(1, BitCount(1));
	MyExtensions.AreEqual<int>(3, BitCount(7));

	MyExtensions.AreEqual<int>(0, BitCountFast(0));
	MyExtensions.AreEqual<int>(1, BitCountFast(1));
	MyExtensions.AreEqual<int>(3, BitCountFast(7));
}

// Question: Write simple code tocount the number of bits in a binary representation
// -------- 
public int BitCount(int a) => throw new NotImplementedException();

// Question: Write faster method to count the number of bits in a binary representation
// -------- 
public int BitCountFast(int a) => throw new NotImplementedException();