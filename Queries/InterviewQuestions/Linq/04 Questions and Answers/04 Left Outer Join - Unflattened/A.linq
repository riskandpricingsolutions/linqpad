<Query Kind="Program" />

void Main()
{
	var inseq1 = new[] { (1, "one"), (2, "two"), };
	var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

	var f = inseq1.Select(i =>
	{
		return new
		{
			Left = i,
			Right = inseq2.Where(j => i.Item1 == j.Item1)
		};
	});
	f.Dump();
	
	var q =
	from n in inseq1
	select new
	{
		Left = n,
		Right =
	from m in inseq2
	where m.Item1 == n.Item1
	select m
	};
	q.Dump();






}