<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

var names = new[] { "Wren", "Bill", "Bob", "Will" };

IEnumerable<(char,string)> s1 =
	from 	n in names
	let 	c = n[0]
	orderby c
	select  (c,n);

s1.Dump();

// Fluent Syntax
IEnumerable<(char,string)> s2 =
	names
		.Select(n => new {c=n[0], n=n})
		.OrderBy(x => x.c)
		.Select(x => (x.c,x.n));

s2.Dump();