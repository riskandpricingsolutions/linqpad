<Query Kind="Program" />

void Main()
{
	byte a = 0b00001110;
	byte b = 0b00010011;
	
	//MyExtensions.AreEqual(b,NextLargestSame1Count(a));
	
	byte c = 0b01001111;
	byte d = 0b00111110;
	MyExtensions.AreEqual(d,NextSmallestSame1Count(c));
}

public byte NextSmallestSame1Count(byte x)
{
	Console.WriteLine($"x     {Convert.ToString(x, 2).PadLeft(8, '0')}");
	
	int zeroCount = 0;
		
	for (int i = 0; i < sizeof(byte) * 8; i++)
	{
		if (((x >> i) & 1) != 0)
		{
			// If this condition is true the bit at the 
			// current index is set and there exists 
			// unset bits to the right of it.  
			// We can do a switch
			if (zeroCount > 0)
			{
				// 1. Unset the bit at the current index. 
				//    To do this we form a mask of all 1s
				//    except at index i where it has a zero.
				//    The mask is anded with x to unset bit i
				byte mask1 =(byte)~(1 << i);
				x &= mask1;
				Console.WriteLine($"mask1 {Convert.ToString(mask1, 2).PadLeft(8, '0')}");
				Console.WriteLine($"x     {Convert.ToString(x, 2).PadLeft(8, '0')}");
				
				// 2. The index of the unset bit is i. We want to
				//    clear all bits to the right of i. That is 
				//    we want to clear bits 0 through i-1 or
				//    the leftmost i bits. We define a mask that
				//    consists of i 0s in positions 0 through i-1
				//    and the rest 1s. We and the mask with x to clear
				byte mask2 =(byte)(~0 << i);
				Console.WriteLine($"mask2  {Convert.ToString(mask2, 2).PadLeft(8, '0')}");
				x &= mask2;
				Console.WriteLine($"x     {Convert.ToString(x, 2).PadLeft(8, '0')}");

				// 4. We originally had (i+1-zeroCount) 1 digits.
				//    We need to these  back in location i-1
				//    i-1-(i+1-zeroCount)
				int oneCount = i +1 - zeroCount;
				byte mask3 = (byte)((1 << oneCount) -1);
				Console.WriteLine($"mask3 {Convert.ToString(mask3, 2).PadLeft(8, '0')}");
				
				// 5. Shift the mask into position
				mask3 = (byte)(mask3 << (i-oneCount));
				Console.WriteLine($"mask3 {Convert.ToString(mask3, 2).PadLeft(8, '0')}");
				
				// 6. Apply the mask
				x |= mask3;
				Console.WriteLine($"x     {Convert.ToString(x, 2).PadLeft(8, '0')}");
				break;
			}
		}
		else 
		{
			zeroCount++;
		}
	}
	return x;
}

public byte NextLargestSame1Count(byte x)
{
	int onesCount = 0;

	for (int i = 0; i < sizeof(byte) * 8; i++)
	{
		// We have found the first non-trailing zero
		if (((x >> i) & 1) == 0)
		{
			if (onesCount > 0)
			{
				// Flip first non-trailing zero to 1
				x |= (byte)(1 << i);
				
				// Zero locations right of flipped digit
				x &= (byte)(~1 << (i-1)); 
				
				// add back in onesCount-1 1s in lsb locations
				x |= (byte)((1 << onesCount-1)-1);
				
				break;
			}	
		}
		else
		{
			onesCount++;
		}
	}
	return x;
}
