<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// Question. Use Dynamic array such that we can invoke Speak on cat and dog 
	// without having a common base class.
	
	dynamic[] ar = new dynamic[2];
	ar[0] = new Dog();
	ar[1] = new Cat();
	
	foreach (var element in ar) element.Speak();
}

public class Dog
{
	public void Speak( ) => Console.WriteLine("Woof");
}

public class Cat
{
	public void Speak() => Console.WriteLine("Meah");
}