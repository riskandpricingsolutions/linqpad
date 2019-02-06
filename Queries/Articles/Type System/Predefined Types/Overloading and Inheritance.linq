<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	Base b = new Sub();
	DoIt(b);
}

public void DoIt(Base b) => WriteLine("DoIt(Base)");
public void DoIt(Sub b) => WriteLine("DoIt(Sub)");

public class Base { }
public class Sub : Base { }