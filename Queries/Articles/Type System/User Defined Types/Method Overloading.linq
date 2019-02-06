<Query Kind="Program" />

void Main()
{
	
}

public class ValidMethodOverloaded
{
	// Valid overload as both methods have 
	// different signatures. Whether a param is 
	// reference forms part of the signature
	public void SingleParamMethod(int a) {}
	public void SingleParamMethod(ref int a) {}
}

public class InvalidMethodOverloaded
{
	// Invalid as both methods have the same signature
	// Cannot define overloaded methods that differ 
	// only on ref and out
	public void SingleParamMethod(ref int a) { }
	public void SingleParamMethod(out int a) { }
}
// Define other methods and classes here

