<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	MyStruct a = new MyStruct {Value = 1};
	MyStruct b = new MyStruct {Value = 1};
	WriteLine(a.Equals(b)); // true
}


public struct MyStruct 
{ 
	public int Value;

	public override bool Equals(object obj) 
		=> Value == (obj as MyStruct?)?.Value;
}