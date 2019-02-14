<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	IntWrapper a = new IntWrapper() {Value = 5};
	IntWrapper b = new IntWrapper() {Value = 5};
	WriteLine(a == b);
	
	object c = a;
	WriteLine(b == c);
	WriteLine(c == b);
	
}

public class IntWrapper 
{
	public static bool operator ==(IntWrapper a, IntWrapper b) => a.Value == b.Value;
	public static bool operator !=(IntWrapper a, IntWrapper b) => a.Value != b.Value;
	public int Value;
}


// Define other methods and classes here