<Query Kind="Program" />

void Main()
{
	var inseq1 = new[] { (1, "one"), (2, "two"), };
	var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };
	
	var f =inseq1.Select(i => (i,inseq2));
	f.Dump();
	
	var q = from i in inseq1 select (i,inseq2);
	q.Dump();

}