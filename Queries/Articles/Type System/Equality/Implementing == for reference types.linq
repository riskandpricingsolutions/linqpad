<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	MyReference a = new MyReference {Value = 1};
	MyReference b = new MyReference {Value = 1};
	WriteLine(a == b); // true
	
	WriteLine(a == (object)b); // false
	WriteLine((object)a == b); // false
}


public class MyReference 
{ 
	public int Value;
	
	public static bool operator==(MyReference a, MyReference b) => a.Value == b.Value;
	public static bool operator!=(MyReference a, MyReference b) => a.Value == b.Value;
}