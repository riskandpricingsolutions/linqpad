<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	MyReference a = new MyReference {Value = 1};
	MyReference b = new MyReference {Value = 1};
	WriteLine(a.Equals(b));
}


public class MyReference { public int Value;}