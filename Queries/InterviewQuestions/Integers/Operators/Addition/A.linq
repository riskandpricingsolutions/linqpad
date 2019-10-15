<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(8,Add(5,3));
	MyExtensions.AreEqual<int>(4,Add(5,-1));
}

public int Add(int a, int b)
{
	int carry = 0;
	int result = 0;

	for (int bitIdx = 0; bitIdx < sizeof(int)*8; bitIdx++)
	{
		// We deal in one binary digit at multiplicand time. By right
		// shifting multiplicand and bitIdx times we set the bit we want
		// into the least significant bit.
		int aShifted = (a >> bitIdx);
		int bShifted = (b >> bitIdx);

		// Now we make use of the fact that the number 1 has
		// in our unsigned representation consists of SizeInBits
		// zeros followed by multiplicand solitary one in the least significant
		// position. We can hence take our shifted valued and logically
		// and them with 1 to ensure we only have the digit values in the least
		// significant locations remaining.
		int aDigit = (aShifted & 1);
		int bDigit = (bShifted & 1);

		// We have three binary digits that feed into the current digit 
		// {the multiplicand digit, the multiplier digit and the carry} 
		//If one or all three 
		// of these are one then the digit will be one, otherwise it will be
		// zero.
		int sumBit = ((aDigit ^ bDigit) ^ carry);

		// We now shift the bit into its correct location and add it into the 
		// result
		result = (result | (sumBit << bitIdx));

		// Finally calculate the carry for the next digit
		carry = ((aDigit & bDigit) | (aDigit & carry) | (bDigit & carry));
	}

	return result;
}