<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// Anonymous type
	var place = new { Street = "Worple Road", Number = 20 };
	WriteLine(place.Street);
	
	// Equality and hashing are overriden to use values
	var a = new { Street = "Worple Road", Number = 20 };
	var b = new { Street = "Worple Road", Number = 20 };
	WriteLine(a.Equals(b)); // true
	WriteLine( a == b); // false
	
	var aa = new Dictionary<Object,string>();
	aa[a] = "hello";
	WriteLine(aa.ContainsKey(b));  // true

	// The compiler is clever enough to only generate 
	// one type in the following situation
	var c = new { Street = "Worple Road", Number = 20 };
	var d = new { Street = "Worple Road", Number = 20 };
	WriteLine(c.GetType() == d.GetType()); // true
	
	// we can create arrays of anonymous types
	
	var ar = new[]
	{
		new { Street = "Worple Road", Number = 20 },
		new { Street = "Worple Road", Number = 25 }
	}
}

// Define other methods and classes here
