<Query Kind="Program" />

void Main()
{
	string a = "Hello World";

	ref string b = ref GetString(ref a);

	b = "World";
	Console.WriteLine(a);
}

public ref String GetString(ref String inputString)
{
	return ref inputString;
}

// Define other methods and classes here