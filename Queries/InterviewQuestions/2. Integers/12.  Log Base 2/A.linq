<Query Kind="Program" />

void Main()
{	
	MyExtensions.AreEqual(0,LogBrute(1));
	MyExtensions.AreEqual(1,LogBrute(2));
	MyExtensions.AreEqual(1,LogBrute(3));
	MyExtensions.AreEqual(2,LogBrute(4));
	MyExtensions.AreEqual(2,LogBrute(5));

	MyExtensions.AreEqual(0, LogOpt(1));
	MyExtensions.AreEqual(1, LogOpt(2));
	MyExtensions.AreEqual(1, LogOpt(3));
	MyExtensions.AreEqual(2, LogOpt(4));
	MyExtensions.AreEqual(2, LogOpt(5));

}

// Question: Write brute force algorithm to calculate 
// --------floor(log(x)) to base 2
public byte LogBrute(byte x)
{
	if (x<=0) throw new ArgumentException();
	byte shiftCount =0;
	
	while (x >0)
	{
		x >>=1;
		shiftCount++;
	}
	
	return (byte)(shiftCount -1);
}

// Question: optimised algorithm to calculate 
// --------floor(log(x)) to base 2
public int LogOpt(int x)
{
	int e = 0;
	
	if ((x &(~((1<<16)-1))) != 0)
	{
		// We have set digits in location 16-31 so we don't 
		// care about the digits in locations 0-15. Add 16 
		// and shift right to home in on exact location
		x >>= 16; e += 16;
	}
		
	if ((x &(~((1<<8)-1))) != 0)
	{
		// We have set digits in location 8-15 so we don't 
		// care about the digits in locations 0-7. Add 8 
		// and shift right to home in on exact location
		x >>= 8; e += 8;
	}
		
	if ((x &(~((1<<4)-1))) != 0)
	{
		// We have set digits in location 4-7 so we don't 
		// care about the digits in locations 0-3. Add 4
		// and shift right to home in on exact location
		x >>= 4; e += 4;
	}
		
	if ((x &(~((1<<2)-1))) != 0)
	{
		// We have set digits in location 2-3 so we don't 
		// care about the digits in locations 0-1. Add 2
		// and shift right to home in on exact location
		x >>= 2; e += 2;
	}
		
	if ((x &(~((1<<1)-1))) != 0)
	{
		// Finally is the digit in slot index 0 or 1
		e += 1;
	}
			
	return e;
}

public int LogOpt2(int x)
{
	int e = 0;
	int shift = (sizeof(int) * 8) /2;

	while (shift <= 1)
	{
		if ((x & (~((1 << shift) - 1))) != 0)
		{
			x >>= shift; e += shift;
			shift /=2;
		}
	}

	return e;
}



// Define other methods and classes here
