<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	MyReference a = new MyReference {Value = 1};
	MyReference b = new MyReference {Value = 1};
	
	// If the static type is MyReference use MyReference 
	// equality operator which implements value equality
	WriteLine( a==b);

	// If the static type is Object use Object 
	// equality operator which uses referential equality
	WriteLine( (Object)a==(Object)b);
}


public class MyReference {
	public int Value;
	
	public static bool operator== (MyReference a, MyReference b) => a.Value == b.Value;
	public static bool operator!= (MyReference a, MyReference b) => a.Value != b.Value;
}