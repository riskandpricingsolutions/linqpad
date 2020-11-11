<Query Kind="Program" />

void Main()
{
	new Person();
}

public class Person
{
	private int _age;
	
	public int Age 
	{
		get => _age;
		set => _age = value;
	}
	
	public Person() => Console.WriteLine("Person");
	
	
}