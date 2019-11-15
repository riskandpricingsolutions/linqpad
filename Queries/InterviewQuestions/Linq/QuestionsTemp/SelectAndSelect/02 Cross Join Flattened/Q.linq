<Query Kind="Program" />

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

	var f1 = s1.SelectMany(s => s2, (e1, e2) => new { Left = e1, Right = e2});
	f1.Dump();
	
	var q1 =from e1 in s1
	from e2 in s2
	select new { Left = e1, Right = e2};
	q1.Dump();
}