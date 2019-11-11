<Query Kind="Program" />

void Main()
{
	// Question: Wtie the fluent equivanelt of this query
	var names = new[] { "Wren", "Bill", "Bob", "Will" };
	IEnumerable<string> s1 =
		from n in names
		orderby n.Length, n
		select n.ToUpper();
	s1.Dump();

	var q2 = names
		.OrderBy(n=>n.Length)
		.ThenBy(n => n)
		.Select(n => n.ToUpper());
	

}