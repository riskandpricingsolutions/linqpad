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
public int BitCount(int a) 
{
	int numbits = sizeof(int) * 8;
	int count = 0;
	for (int i = 0; i < numbits; i++)
	{
		if ((a >> i & 1) != 0)
			count++;
	}
	
	return count;
}

// Question: Write faster method to count the number of bits in a binary representation
// -------- 
public int BitCountFast(int a) 
{
	int count = 0;

	while (a != 0)
	{
		a &= a - 1;
		count++;
	}
	
	return count;
}