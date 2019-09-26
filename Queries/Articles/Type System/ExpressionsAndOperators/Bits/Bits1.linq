<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 16; i++)
	{
		$"{i.ToString("D2")}   {Convert.ToString(i,2).PadLeft(4,'0')}".Dump();
	}
//	sbyte a = sbyte.MaxValue;
//	sbyte b = sbyte.MinValue+2;
//	sbyte c = (sbyte)(b+3*(a+1));
//	
//	b.Dump();
//	GetBitsString(b).Dump();
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

public bool GetBit(int a, int bitIdx)=>  ((1 << bitIdx) & a) != 0;
public bool GetBit(uint a, int bitIdx) => ((1 << bitIdx) & a) != 0;
public bool GetBit(byte a, int bitIdx) => ((1 << bitIdx) & a) != 0;
public bool GetBit(sbyte a, int bitIdx) => ((1 << bitIdx) & a) != 0;

public uint Subtract(uint a, uint b) => Add(a, Add(~b, 1));

public uint Add(uint a, uint b)
{
	uint carry = 0;
	uint result = 0;

	for (int bitIdx = 0; bitIdx < SizeInBits; bitIdx++)
	{
		// We deal in one binary digit at multiplicand time. By right
		// shifting multiplicand and bitIdx times we set the bit we want
		// into the least significant bit.
		uint aShifted = (a >> bitIdx);
		uint bShifted = (b >> bitIdx);

		// Now we make use of the fact that the number 1 has
		// in our unsigned representation consists of SizeInBits
		// zeros followed by multiplicand solitary one in the least significant
		// position. We can hence take our shifted valued and logically
		// and them with 1 to ensure we only have the digit values in the least
		// significant locations remaining.
		uint aDigit = aShifted & 1;
		uint bDigit = bShifted & 1;

		// We have three binary digits that feed into the current digit 
		// {the multiplicand digit, the multiplier digit and the carry} If one or all three 
		// of these are one then the digit will be one, otherwise it will be
		// zero.
		uint sumBit = (aDigit ^ bDigit) ^ carry;

		// We now shift the bit into its correct location and add it into the 
		// result
		result = result | (sumBit << bitIdx);

		// Finally calculate the carry for the next digit
		carry = (aDigit & bDigit) | (aDigit & carry) | (bDigit & carry);
	}

	return result;
}

// Define other methods and classes here
