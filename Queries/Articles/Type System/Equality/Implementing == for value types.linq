<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	MyReference a = new MyReference {Value = 1};
	MyReference b = new MyReference {Value = 1};

	MyStruct c = new MyStruct { Value = 1 };
	MyStruct d = new MyStruct { Value = 1 };
	
	// The default implementation of Equals for
	// reference types performs reference equality

	WriteLine(a.Equals(b));

	// The default implementation of Equals for
	// value types performs value equality
	WriteLine(c.Equals(d));
}


public class MyReference { public int Value;}

public struct MyStruct { public int Value;}
