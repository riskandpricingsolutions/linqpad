<Query Kind="Program" />

void Main()
{
	// Question: Wtie the fluent equivanelt of this query
	var names = new[] { "Wren", "Bill", "Bob", "Will" };

	IEnumerable<(char, string)> s1 =
		from n in names
		let c = n[0]
		orderby c
		select (c, n);

	s1.Dump();

}