<Query Kind="Program" />

void Main()
{
	// Method 1
	byte a = 0b00001110;
	$"a         {Convert.ToString(a, 2).PadLeft(8, '0')}".Dump();
	$"a & a-1   {Convert.ToString(a & a-1,2).PadLeft(8,'0')}".Dump();

	// Method 1
	$"a         {Convert.ToString(a, 2).PadLeft(8, '0')}".Dump();
	$"-a        {Convert.ToString(-a, 2).PadLeft(8, '0')}".Dump();
	$"a^-a        {Convert.ToString(a&-a, 2).PadLeft(8, '0')}".Dump();

}

// Define other methods and classes here
