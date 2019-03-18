<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	MyStruct c = new MyStruct { Value = 1 };
	MyStruct d = new MyStruct { Value = 1 };
	WriteLine(c == d); // true
}

public struct MyStruct
{
	public int Value;
	public static bool operator ==(MyStruct a, MyStruct b) => a.Value == b.Value;
	public static bool operator !=(MyStruct a, MyStruct b) => a.Value == b.Value;
}