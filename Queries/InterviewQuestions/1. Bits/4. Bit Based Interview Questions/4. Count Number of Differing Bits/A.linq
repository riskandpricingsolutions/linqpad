<Query Kind="Program" />

void Main()
{	
	MyExtensions.AreEqual(8,CountDifference(0b01010101,0b10101010));
	MyExtensions.AreEqual(0,CountDifference(0b00000000,0b00000000));
	MyExtensions.AreEqual(4,CountDifference(0b01011111,0b10101111));
}

// Question: Write algorithm to count the difference bits between a and b
// --------
public int CountDifference(byte a, byte b)
{
	byte diff = (byte)(a ^ b);
	int count = 0;
	
	while (diff != 0)
	{
		diff = (byte)(diff & (diff-1));
		count++;
	}
	return count;
}

