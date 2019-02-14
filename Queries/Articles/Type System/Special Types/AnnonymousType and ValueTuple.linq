<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// Anonymous type
	var place = new { Street = "Worple Road", Number = 20};
	WriteLine(place.Street);
	
	// Anonymous type equality
	WriteLine(new { Street = "Worple Road", Number = 20}.Equals(new { Street = "Worple Road", Number = 20}));
	
}

// Define other methods and classes here
