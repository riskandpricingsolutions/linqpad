<Query Kind="Program" />

void Main()
{
	MainClass.MainMethod
}


class BaseClass { }

class SubClass : BaseClass { }

class MainClass
{
	public static void AMethod(BaseClass br) { }
	public static void AMethod(SubClass br) { }

	public static void MainMethod()
	{
		BaseClass c = new SubClass();

		AMethod(c);
	}
}
