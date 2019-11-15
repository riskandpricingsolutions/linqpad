<Query Kind="Statements" />

IEnumerable<(int, string)> sOuter = new[] { (1, "one"), (2, "two"), };
IEnumerable<(int, string)> sInner = new[] { (1, "Ensimmäinen"), (1, "Ett") };

// Uncorrelated Subquery in query syntax
IEnumerable<((int, string), IEnumerable<(int, string)>)> sOut =
	from i in sOuter
	select (Left: i, Right: from j in sInner select j);

// Uncorrelated Subquery in fluent syntax
IEnumerable<((int, string), IEnumerable<(int, string)>)> sOut2 =
	sOuter.Select(i => (Left: i, Right: sInner.Select(j => j)));


sOut.Dump();
sOut2.Dump();