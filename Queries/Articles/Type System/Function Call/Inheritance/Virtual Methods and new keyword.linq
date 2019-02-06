<Query Kind="Program" />

public static void MainMethod()
{
	SubClass c = new SubClass();
	BaseClass bref = c;

	// Even though the base class method is virtual, because we
	// didnt override it and instead used the new keyword, once
	// again the method invoked is based on the compile time type

	// Call SubClass.NonVirtualMethod
	c.VirtualMethod();

	// Call BaseClass.NonVirtualMethod
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


	public new void VirtualMethod()
	{
		Console.WriteLine("SubClass.VirtualMethod()");
	}
}


