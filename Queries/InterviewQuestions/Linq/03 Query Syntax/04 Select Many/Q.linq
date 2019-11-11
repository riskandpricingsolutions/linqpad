<Query Kind="Program" />

void Main()
{
	// Question: Write the fluent equivalent of this query
	var names = new[] { "Wren", "Bill", "Bob", "Will" };
	IEnumerable<char> q1 =
		from n in names
		from c in n
		select c;
	q1.Dump();


}