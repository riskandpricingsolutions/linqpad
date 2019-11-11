<Query Kind="Program" />

void Main()
{
	// Question: Use SelectMany to created a flattened inner  join
	var inseq1 = new[] { (1, "one"), (2, "two"), };
	var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };


	var res = inseq1.SelectMany(i => inseq2.Where(j => i.Item1 == j.Item1).Select(j => (i, j)));
	res.Dump();

}