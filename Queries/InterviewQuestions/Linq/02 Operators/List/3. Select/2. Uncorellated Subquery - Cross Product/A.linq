<Query Kind="Program" />

void Main()
{
	// Question: Write a uncorrelated subquery that produces an unflattened
	// cross product
	var inseq1 = new[] { (1, "one"), (2, "two"), };
	var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

	var f1 = inseq1.Select(i => (i, inseq2.Select(j => j)));

	f1.Dump();

}