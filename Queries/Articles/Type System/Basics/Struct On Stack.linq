<Query Kind="Program" />

void Main()
{
	MyClass a = new MyClass();
	a._a = 7;
	a._b = 5;
	
	MyClass b = new MyClass();
	b._a = 11;
	b._b = 13;
}

public struct MyClass 
{
	public double _a;
	public double _b;
}

// Define other methods and classes here