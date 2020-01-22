<Query Kind="Program" />

void Main()
{
	int i = 2,j=4;
	byte x = 0b00000010;
	byte y = 0b00011011;
	byte c = 0b00001011;
	MyExtensions.AreEqual(c, CopyBits(x,y,i,j));
}

// Question: Given two integers x,y and two indices i,j
// --------  write code to copy the first (j-1+1) nits from
//           x into bits i-j in y (inclusive)
byte CopyBits(byte x, byte y, int i, int j)
{
	// 1. Clear the bits in y from i=j inclusive
	byte mask = (byte)~(((1 << (j-i+1))-1)<<i);
	y = (byte)(y & mask);
	
	// 2 Shift x into position
	x = (byte)(x << i);
	
	// 3. And together results of step 1 and 2
	return (byte)(x | y);
}


