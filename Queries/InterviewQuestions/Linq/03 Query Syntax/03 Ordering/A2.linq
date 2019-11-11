<Query Kind="Program" />

void Main()
{
	// Question: Write the query equivalent of this query
	var names = new[] { "Wren", "Bill", "Bob", "Will" };
	IEnumerable<string> s2 =
		names
		.OrderByDescending(n => n.Length)
		.ThenByDescending(n => n)
		.Select(n => n.ToUpper());
	s2.Dump();
	
	var q2 = from n in names
	orderby n.Length descending, n descending
	select n.ToUpper();
	q2.Dump();

}