<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// By default reference types use reference equality
	MyReference a = new MyReference {Value = 1};
	MyReference b = new MyReference {Value = 1};
	WriteLine( a.Equals(b));
}


public struct MyReference {
	public int Value;
}