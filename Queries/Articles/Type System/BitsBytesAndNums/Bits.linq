<Query Kind="Program" />

void Main()
{
	sbyte a = -96;
	sbyte b = (sbyte)(a >> 2);
	b.Dump();

	byte c = 128+64;
	byte d = (byte)(c >> 2);

	GetBitsString(a).Dump();
	GetBitsString(b).Dump();
	
	sbyte result = GetNext(0b01011111);
	string resString = GetBitsString(result);
	
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

public bool GetBit(sbyte a, int bitIdx) => ((1 << bitIdx) & a) != 0;

public bool GetBit(byte a, int bitIdx) => ((1 << bitIdx) & a) != 0;