<Query Kind="Statements" />

var s1 = new[] { (1, "one"), (2, "two"), };
var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };


var f =s1
	.Select(e1 => new {Left=e1, Right=s2});
f.Dump();

var q = from e1 in s1 
select new {Left=e1, Right=s2};
q.Dump();