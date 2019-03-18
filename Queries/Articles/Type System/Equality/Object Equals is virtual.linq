<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	Object a = new MyReference {Value = 1};
	Object b = new MyReference {Value = 1};
	

	WriteLine(a.Equals(b));
}


public class MyReference {
	public int Value;
	
	public static bool operator== (MyReference a, MyReference b) => a.Value == b.Value;
	public static bool operator!= (MyReference a, MyReference b) => a.Value != b.Value;

	public override bool Equals(object obj)
	{
		MyReference other = obj as MyReference;
		
		return this == other;
	}
}