<Query Kind="Program" />

void Main()
{
	SubClass c = new SubClass();
	BaseClass bref = c;

	// As the method is defined as virtual in the base class
	// and overriden in the subclass all calls are polymorphic.
	// The run-time type of the actual object and not the 
	// compile-timetype of the reference determine which method 
	// is called

	bref.VirtualMethod();
}

class BaseClass
{
	public BaseClass()
	{
		Console.WriteLine("BaseClass()");
	}

	public virtual void VirtualMethod()
	{
		Console.WriteLine("BaseClass.VirtualMethod()");
	}
}

class SubClass : BaseClass
{
	public SubClass() { Console.WriteLine("SubClass()"); }


	public override void VirtualMethod()
	{
		Console.WriteLine("SubClass.VirtualMethod()");
	}
}