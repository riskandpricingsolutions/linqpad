<Query Kind="Program" />

void Main()
{
	byte[,] a = new byte[3, 2]
	{
				{0, 1},
				{2, 3},
				{4, 5}
	};

	byte[,] b = new byte[2, 3]
	{
				{0, 1,2},
				{3, 4,5}
	};
	
	Console.WriteLine(a[1,0]);
	Console.WriteLine(b[1,0]);
}