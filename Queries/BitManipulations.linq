<Query Kind="Program" />

void Main()
{
	// Create a mask with a single 1 in bit location 3
	GetBitsString((byte)(1<<3)).Dump();

	// Create a mask with a single zero in bit location 3
	GetBitsString(unchecked((byte)(~(1 << 3)))).Dump();

	// Create mask with first 3 bits of value zero
	GetBitsString(unchecked((byte)(~0 << 3))).Dump();
	
	// Create mask with first 3 bits of value one
	GetBitsString(unchecked((byte)((1 << 3)-1))).Dump();
	
	// Create mask with ones in bits 2 through 4 inclusive
	GetBitsString(unchecked((byte)(((1 << 4-2+1)-1)<<2))).Dump();

	// Create a mask with zeros in bits 2 through 4 inclusive
	GetBitsString((unchecked((byte)~(((1 << 4 - 2 + 1) - 1) << 2)))).Dump();
	
	// Set the bit in location 2 to one
	GetBitsString((byte)((1 << 2) | 0b00101000)).Dump();

	// Set the bit in location 2 to zero
	GetBitsString((byte)(~(1 << 2) & 0b00101100)).Dump();

	// Get the value of bit 3
	((byte)((0b00101100 >> 3) & 1)).Dump();
	
	
	// Clear 3 least significant digits
	GetBitsString(((byte)((~0 << 3) & 0b10101111))).Dump();


	// Set 3 least significant digits
	GetBitsString(((byte)(((1 << 3)-1) | 0b10100000))).Dump();

	// Subtract 3 without using - key
	(5 + ~3 +1).Dump();
	
}



public bool IsBitSet(int intVal, int bitIdx)
{
	var mask = 1 << bitIdx;
	return (mask & intVal) != 0;
}

public int SetBit(int a, int bitIdx)
{
	var mask = 1 << bitIdx;
	return mask | a;
}

public int ClearBit(int a, int bitIdx)
{
	var mask = ~(1 << bitIdx);
	return mask & a;
}

public sbyte GetNext(sbyte a)
{
	int oneCount = 0;
	// Find the first number 0 with a 1 to its right
	for (int i = 0; i < sizeof(sbyte)*8; i++)
	{
		bool isCurrentBitSet = ((a >> i) & 1) != 0;
		
		if (!isCurrentBitSet && oneCount >0 )
		{
			// We have found the bit to flip
			sbyte result = (sbyte)((1 << i) | a);
			string resString = GetBitsString(result).Dump();
			
			// mask to set all bytes in locations 0..i-1 to zero
			sbyte mask = (sbyte)(-1 << (i));	
			string maskString = GetBitsString(mask).Dump();
			result = (sbyte)(mask & result);
			string resString2 = GetBitsString(result).Dump();
			
			
			// set oneCount-1 ones in least significant locations
			sbyte mask2 = (sbyte)(~(-1 << (oneCount-1)));
			string mask2String = GetBitsString(mask2).Dump();
			result = (sbyte)(mask2 | result);
			return result;
		}
		
		if (isCurrentBitSet) oneCount++;

	}
	
	throw new ArgumentException();
}

public string GetBitsString(sbyte a)
{
	var bitCount = sizeof(sbyte) * 8;
	StringBuilder b = new StringBuilder(bitCount);

	for (int i = bitCount - 1; i >= 0; i--)
	{
		b.Append(GetBit(a, (i)) ? '1' : '0');
	}

	return b.ToString();
}

public string GetBitsString(int a)
{
	var bitCount = sizeof(int) * 8;
	StringBuilder b = new StringBuilder(bitCount);

	for (int i = bitCount - 1; i >= 0; i--)
	{
		b.Append(GetBit(a, (i)) ? '1' : '0');
	}

	return b.ToString();
}

public string GetBitsString(byte a)
{
	var bitCount = sizeof(byte) * 8;
	StringBuilder b = new StringBuilder(bitCount);

	for (int i = bitCount - 1; i >= 0; i--)
	{
		b.Append(GetBit(a, (i)) ? '1' : '0');
	}

	return b.ToString();
}

public bool GetBit(int a, int bitIdx) => ((1 << bitIdx) & a) != 0;

public bool GetBit(sbyte a, int bitIdx) => ((1 << bitIdx) & a) != 0;

public bool GetBit(byte a, int bitIdx) => ((1 << bitIdx) & a) != 0;