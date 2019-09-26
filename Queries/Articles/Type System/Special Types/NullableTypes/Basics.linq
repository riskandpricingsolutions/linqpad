<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// Introducing Nullable<int>
	int? nullable = null;

	// Equivalent
	bool isNull = nullable == null;	
	bool isNull2 = !nullable.HasValue;
	
	// Boxing knows to box the actual value type 
	// and not the nullable value type
	object o = nullable;
	
	// Unboxing is supported
	int? b = o as int?;
	WriteLine(b);
	
	// The compiler lifts operators from the 
	// basic value type to the nullable value type
	// The following can be considered functionally equivalent
	int? x = 5;
	int? y = 6;
	bool eq1 = x < y;
	bool eq2 = (x.HasValue && y.HasValue) ? x.Value < y.Value : false ;
}

// Define other methods and classes here