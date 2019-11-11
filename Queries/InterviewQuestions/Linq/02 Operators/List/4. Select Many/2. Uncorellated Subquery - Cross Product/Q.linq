<Query Kind="Program" />

void Main()
{
	// Question: Use SelectMany to created a flattened cross join
	var inseq1 = new[] { (1, "one"), (2, "two"), };
	var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };


	inseq1.SelectMany(i => inseq2.Select(j => (i,j)));

}