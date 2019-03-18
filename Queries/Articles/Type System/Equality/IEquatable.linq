<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	MyStruct a = new MyStruct { Value = 1 };
	MyStruct b = new MyStruct { Value = 1 };
	WriteLine(a.Equals(b)); // true
}


public struct MyStruct : IEquatable<MyStruct>
{
	public int Value;

	public bool Equals(MyStruct other) 
		=> Value == other.Value;
}