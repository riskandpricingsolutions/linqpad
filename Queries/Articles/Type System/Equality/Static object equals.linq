<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	MyReference a = new MyReference {Value = 1};
	MyReference b = new MyReference {Value = 1};

	MyReference c = null;
	MyReference d = null;
	
	// The static Object.Equals method provides a null-safe,
	// type agnostic equality comparison
	WriteLine(Object.Equals(a,b)); // true
	WriteLine(Object.Equals(c,d)); // true
	WriteLine(Object.Equals(a,c)); // false
	WriteLine(Object.Equals(c,a)); // false

	Object a1 = a;
	Object b1 = b; 
	WriteLine(Object.Equals(a1,b1)); // true

	// Static Object.Equals causes boxing of value types
	MyValue e = new MyValue { Value = 1 };
	MyValue f = new MyValue { Value = 1 };

}


public class MyReference {
	public int Value;
	
	public static bool operator== (MyReference a, MyReference b) => a?.Value == b?.Value;
	public static bool operator!= (MyReference a, MyReference b) => a?.Value != b?.Value;
	public override bool Equals(object obj) => obj as MyReference == this;
}

public struct MyValue
{
	public int Value;

	public static bool operator ==(MyValue a, MyValue b) => a.Value == b.Value;
	public static bool operator !=(MyValue a, MyValue b) => a.Value != b.Value;
}