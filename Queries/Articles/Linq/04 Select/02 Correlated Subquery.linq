<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

IEnumerable<string> sIn = new[] { "Hello World", "Moi Vaimoni", "Miten menee" };

// Correlated Subquery in fluent syntax
IEnumerable<IEnumerable<string>> sOut =
	sIn
		.Select(i => i
			.Split()
			.Select(j => j));

// Correlated Subquery in query syntax
var sOut2 =
	from i in sIn
	select (from j in i.Split() select j);

sOut.Dump();
sOut2.Dump();