<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

var names = new List<String> (new[] { "Kenny", "Wilson"});

IEnumerable<char> q1 =
	from n in names
	from c in n
	select c;


IEnumerable<char> f1 =
	names.SelectMany(n => n);

IEnumerable<char> q2 =
	from n in names
	from c in n
	where n == "Kenny" && c == 'n'
	select Char.ToUpper(c);

IEnumerable<char> f2 =
	names
		.SelectMany(n => n, (n, c) => new {n,c})
		.Where(x => x.n=="Kenny" && x.c=='n')
		.Select(x => Char.ToUpper(x.c));

WriteLine(((IStructuralEquatable)q1.ToArray()).Equals(f1.ToArray(), EqualityComparer<char>.Default));

q2.Dump();
f2.Dump();