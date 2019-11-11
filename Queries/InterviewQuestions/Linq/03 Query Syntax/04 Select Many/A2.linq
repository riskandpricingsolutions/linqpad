<Query Kind="Program" />

void Main()
{
	// Question: Write the fluent equivalent of this query
	var names = new[] { "Wren", "Kenny", "Bob", "Will" };
	IEnumerable<char> q2 =
		from n in names
		from c in n
		where n == "Kenny" && c == 'n'
		select Char.ToUpper(c);
	q2.Dump();

	var f2 = names
		.SelectMany(n => n, (n, c) => new {n,c})
		.Where(x=> x.n=="Kenny" && x.c=='n')
		.Select(x => Char.ToUpper(x.c));
	f2.Dump();
	


}