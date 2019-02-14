<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	VirtualEquals();
}

public void Operators()
{
	IntWrapper a = new IntWrapper() { Value = 5 };
	IntWrapper b = new IntWrapper() { Value = 5 };
	WriteLine(a == b);

	Object c = new IntWrapper() { Value = 5 };
	Object d = new IntWrapper() { Value = 5 };
	WriteLine(c == d);

	WriteLine(a == c);
	WriteLine(c == a);
}

public void VirtualEquals()
{
	IntWrapper a = new IntWrapper() { Value = 5 };
	IntWrapper b = new IntWrapper() { Value = 5 };
	WriteLine(a.Equals(b));
	WriteLine(b.Equals(a));

	Object c = new IntWrapper() { Value = 5 };
	Object d = new IntWrapper() { Value = 5 };
	WriteLine(c.Equals(d));
	WriteLine(d.Equals(c));
}


public class IntWrapper 
{
	public int Value;
	
	public static bool operator == (IntWrapper x, IntWrapper y) => x.Value == y.Value;

	public static bool operator !=(IntWrapper x, IntWrapper y) => x.Value == y.Value;

	public override bool Equals(object obj) => (obj is IntWrapper) ? Value == ((IntWrapper)obj).Value : false;
}


// Define other methods and classes here