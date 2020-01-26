<Query Kind="Program" />

void Main()
{
	
	
	MyExtensions.AreEqual<sbyte>(0b01111110, SwapEvenAndOdd(unchecked((sbyte)0b10111101)));
}

sbyte SwapEvenAndOdd2(sbyte x)
{
	// 1. Define the masks
	sbyte oddMask = unchecked((sbyte)0xaa);
	sbyte evenMask = unchecked((sbyte)0b01010101);
	Console.WriteLine($"mask odd  {Convert.ToString(oddMask, 2).PadLeft(8, '0')}");
	Console.WriteLine($"mask even {Convert.ToString(evenMask, 2).PadLeft(8, '0')}");
	
	// 2. Separate out the even and odd bits
	sbyte xEven = (sbyte)(x & evenMask);
	sbyte xOdd = (sbyte)(x & oddMask);
	Console.WriteLine($"x    odd  {Convert.ToString(xOdd, 2).PadLeft(8, '0')}");
	Console.WriteLine($"x    even {Convert.ToString(xEven, 2).PadLeft(8, '0')}");

	// 3. Move odd bits into even positions and
	//   even bits into odd bit. Notice the cast to int 
	//   to compensate fro C# having only arithmetic shift
	//   operators.
	xEven = (sbyte)(xEven << 1);
	xOdd = (sbyte)(((byte)xOdd) >> 1);
	Console.WriteLine($"x    odd  {Convert.ToString(xOdd, 2).PadLeft(8, '0')}");
	Console.WriteLine($"x    even {Convert.ToString(xEven, 2).PadLeft(8, '0')}");
	return (sbyte)(xEven | xOdd);
}

sbyte SwapEvenAndOdd(sbyte x)
{
	// 1. Define the masks
	sbyte oddMask = unchecked((sbyte)0xaa);
	sbyte evenMask = unchecked((sbyte)0b01010101);

	// 2. Separate out the even and odd bits
	sbyte xEven = (sbyte)(x & evenMask);
	sbyte xOdd = (sbyte)(x & oddMask);

	// 3. Move odd bits into even positions and
	//   even bits into odd bit. Notice the cast to int 
	//   to compensate fro C# having only arithmetic shift
	//   operators.
	xEven = (sbyte)(xEven << 1);
	xOdd = (sbyte)(((byte)xOdd) >> 1);
	return (sbyte)(xEven | xOdd);
}

// Define other methods and classes here