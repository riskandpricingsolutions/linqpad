<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	int a = 10;
	int b = 10;
	WriteLine(a == b);
	
	IntWrapper c = new IntWrapper {Value = 11};
	IntWrapper d = new IntWrapper {Value = 11};
	WriteLine(c == d);
}

public struct IntWrapper 
{	
	public static bool operator == (IntWrapper a, IntWrapper b) => a.Value == b.Value;
	public static bool operator != (IntWrapper a, IntWrapper b) => a.Value != b.Value;
	
	public int Value;
}


// Define other methods and classes here
