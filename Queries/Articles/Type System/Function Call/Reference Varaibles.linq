<Query Kind="Program" />

void Main()
{
	byte x = 1;

	byte a = 5;
	ref byte b = ref a;
	b = 4;
	Console.WriteLine(a);
}



// Define other methods and classes here