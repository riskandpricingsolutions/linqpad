<Query Kind="Program" />

void Main()
{
	C c = new C();
	B b = c;
	A a = b;
	
	c.DoSomething();
	b.DoSomething();
	a.DoSomething();
}

public class A
{
	public void DoSomething() => Console.WriteLine("A:DoSomething");
}

public class B : A
{
	public new void DoSomething() => Console.WriteLine("B:DoSomething");
}

public class C : B {}


// Define other methods and classes here