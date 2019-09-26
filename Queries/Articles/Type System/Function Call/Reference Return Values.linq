<Query Kind="Program" />

void Main()
{
	Person p =new Person() {_name="Kenny"};
	ref string b = ref GetString(p);
	b = "John";
	Console.WriteLine(p);
}

public ref String GetString(Person p)
{
	return ref p._name;
}

public class Person
{
	public String _name ;	
	public override string ToString() => _name;
}
