<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

public class ConversionExample1
{
	public String Convert<T>(T arg) 
	{
		// Does not compile are compiler not sure
		// whether we are performing a custom 
		// conversion or not
		if ( arg is String)
			return (String)arg;
		
		return "Not a string"
	}
}

public class ConversionExample2
{
	public String Convert<T>(T arg)
	{
		// Compiles because the compiler considers this
		// convertion to object and from object to be either
		// boxing or unboxing conversions
		if (arg is String)
			return (string)(Object)arg;

		return "Not a string"
	}
}
