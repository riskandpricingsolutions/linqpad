<Query Kind="Program" />

void Main()
{
	var inseq1 = new[] { (1, "one"), (2, "two"), };
	var inseq2 = new[] { (1, "ensimmainen"), (1, "ett") };

	// Question: Use select to perform a correlated subquery that
	//           creates an unflattened left outer join
	var result = inseq1.Select(left =>
	{
		return new { Left = left, Right = inseq2.Where(right => left.Item1 == right.Item1) };
	});
	
	result.Dump();

}
