<Query Kind="Statements" />

var s1 = new[] { (1, "one"), (2, "two"), };
var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

var f = s1.Select(e1 => s2.Select(e2 => new { Left = e1, Right = e2 }));

var q = from e1 in s1
select (from e2 in s2 select new { Left = e1, Right = e2 });


f.Dump();