<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(15,UnsignedMultiply(5,3));
	
}

// Question: Write unsigned multiplication
public int UnsignedMultiply(int multiplicant, int multiplier)
{
	int result = 0;
	int numBits = sizeof(int) * 4;
	for( int i =0; i < numBits; i++)
	{
		if (((multiplier >> i) & 1) != 0)
		result |= multiplicant << i;
	}
	
	return result;
}