<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	ContravariantDelegate<object> a = DoSomething;
	
	// Looks a bit strange but it type safe
	ContravariantDelegate<string> b = a;
	a("A String");
}

public void DoSomething(Object obj) {}

delegate void ContravariantDelegate<in TIn>(TIn inputType);

